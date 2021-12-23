using Core.Business.Interfaces;
using Core.Helper;
using Core.Helper.FromFileData;
using Core.Mapper;
using Core.Models.DTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using MySqlX.XDevAPI.Common;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class SlidesBusiness : ISlidesBusiness
    {
        private readonly IRepository<Slides> _repository;
        private readonly IEntityMapper _mapper;
        private readonly IFormFile _imageServices;

        public SlidesBusiness(IRepository<Slides> repository, IEntityMapper mapper, IFormFile imageServices)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServices = imageServices;
        }

        public Slides FindById(int id)
        {
            var slide = _repository.GetById(id) != null ? _repository.GetById(id) : null;


            return slide;
        }

        public async Task<IEnumerable<Slides>> GetAllSlides()
        {
            return await _repository.GetAll();
        }

        public void UpdateSlide(int id, SlideDtoPutRequest slideDto)
        {
            var slide = _repository.GetById(id);
            var slideEdit = _mapper.mapSlideDtoToModelPutRequest(slide, slideDto);
            _repository.Update(slideEdit);
        }


        public void DeleteSlide(Slides slide)
        {

            _repository.Delete(slide.Id);
        }

        public void addSlides(SlideDtoPutRequest newSlide)
        {
            var SlideMapped = _mapper.mapNewSlide(newSlide);

            _repository.Save(SlideMapped);
        }

        public async Task<Result> CreateSlide(SlidesCreateDTO slidesCreateDTO)
        {
            Slides slide;
            byte[] bytesFile = Convert.FromBase64String(slidesCreateDTO.ImageUrl);
            slidesCreateDTO.FileName = ValidateFiles.GetImageExtensionFromFile(bytesFile);
            string uniqueName = "slide_" + DateTime.Now.ToString().Replace(",", "").Replace("/", "").Replace(" ", "");
            var formFile = new FormFileData()
            {
                FileName = slidesCreateDTO.FileName,
                ContentType = slidesCreateDTO.ContentType,
                Name = slidesCreateDTO.Name
            };
            var image = ConvertFile.BinaryToFormFile(bytesFile, formFile);
            var urlImage = await _repository.Save(uniqueName + slidesCreateDTO.FileName, image);
            return urlImage;
        }
    }
}
