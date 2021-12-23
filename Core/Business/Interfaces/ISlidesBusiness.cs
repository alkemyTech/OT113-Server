using Core.Models.DTOs;
using Entities;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface ISlidesBusiness
    {
        Slides FindById(int id);
        Task<IEnumerable<Slides>> GetAllSlides();

        void UpdateSlide(int id, SlideDtoPutRequest slideDto);

        void DeleteSlide(Slides slide);
        void addSlides(SlideDtoPutRequest newSlide);

        public async Task<Result>CreateSlide(SlidesCreateDTO slidesCreateDTO);
    }
}
