using Entities;
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

        void DeleteSlide(Slides slide);
    }
}
