using Abstractions;
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
        Task<IEnumerable<TestimonailsDto>> GetAllTestimonials(IPaginationFilter filter);
        TestimonialDtoResponse AddTestimonials(TestimonialUpdateDto testimonial);
        Testimonials GetTestimonialsById(int id);
        TestimonialDtoResponse UpdateTestimonials(Testimonials testimonial, TestimonialUpdateDto update);
        void RemoveTestimonials(int id);
        int CountTestimonials();
    }
}
