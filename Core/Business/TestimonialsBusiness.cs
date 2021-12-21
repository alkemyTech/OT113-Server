using System;
using Entities;
using Repositories;
using Core.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helper;
using System.Security.Cryptography;
using Core.Models.DTOs;
using Core.Mapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Models;
using Abstractions;

namespace Core.Business
{
   public class TestimonialsBusiness : ITestimonialsBusiness
    {
        
        private readonly IRepository<Testimonials> _repository;
        private readonly IEntityMapper _mapper;
            

        public TestimonialsBusiness(IRepository<Testimonials> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public TestimonialDtoResponse AddTestimonials(TestimonialUpdateDto testimonial) 
        {
            var testimonialMapped = _mapper.TestimonialsMapDto(testimonial);
            _repository.Save(testimonialMapped);
            return _mapper.MapTestimonialResponseDto(testimonialMapped);
        
        }
        public Testimonials GetTestimonialsById(int id) {
            return _repository.GetById(id);
        }
        public TestimonialDtoResponse UpdateTestimonials(Testimonials testimonial, TestimonialUpdateDto update) {
            
            var testimonialUpdate = _mapper.MapUpdateTestimonials(testimonial, update);

            _repository.Update(testimonialUpdate);

            var testimonialResponse = _mapper.MapTestimonialResponseDto(testimonialUpdate);
            return testimonialResponse;
        }

        public void RemoveTestimonials(int id) {
            _repository.Delete(id);
        }
        public async Task<IEnumerable<TestimonailsDto>> GetAllTestimonials(IPaginationFilter filter) 
        {
            var testimonials = await _repository.PaginatedGetAll(filter);
            var mappedTestimonials = _mapper.MapTestimonialstoTestimonialsDto(testimonials);
            return mappedTestimonials;
        }

        public int CountTestimonials()
        {
            return _repository.Count();
        }
     }
 }

