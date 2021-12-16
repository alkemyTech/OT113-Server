using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models.DTOs;
using Entities;
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

        public SlidesBusiness(IRepository<Slides> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Slides FindById(int id)
        {
            var slide =  _repository.GetById(id) != null ? _repository.GetById(id) : null;


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


        public void DeleteSlide(Slides slide){

            _repository.Delete(slide.Id);
        }

    }
}
