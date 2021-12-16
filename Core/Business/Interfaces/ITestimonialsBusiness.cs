using Core.Helper;
using Core.Models;
using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface ITestimonialsBusiness
    {
        Task<PagedList<TestimonailsDto>> GetAllTestimonials(int? pageNumber, int? pageSize);
        void AddTestimonials(TestimonailsDto testimonial);
        Testimonials GetTestimonialsById(int id);
        void UpdateTestimonials(Testimonials testimonial, TestimonialUpdateDto update);
        void RemoveTestimonials(int id);
    }
}
