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

        public void AddTestimonials(TestimonailsDto testimonial) 
        {
            var testimonialMapped = _mapper.TestimonialsMapDto(testimonial);
            _repository.Save(testimonialMapped);
        }
        public Testimonials GetTestimonialsById(int id) {
            return _repository.GetById(id);
        }
        public void UpdateTestimonials(Testimonials testimonial, TestimonialUpdateDto update) {
            _mapper.MapUpdateTestimonials(testimonial, update);

            _repository.Update(testimonial);
        }

        public void RemoveTestimonials(int id) {
            _repository.Delete(id);
        }
        public async Task<PagedList<TestimonailsDto>> GetAllTestimonials(int? pageNumber, int? pageSize) 
        {
            if(pageNumber == null && pageSize == null)
            {
                pageNumber = 1;
                pageSize = 10;
            }

            if(pageSize == null || pageSize > 10 || pageSize < 1)
            {
                pageSize = 10;
            }

            var testimonials = await _repository.GetAll();
            var mappedTestimonials = _mapper.MapTestimonialstoTestimonialsDto(testimonials);
            return PagedList<TestimonailsDto>.Create(mappedTestimonials.AsQueryable(), pageNumber.Value, pageSize.Value);
        }
     }
 }

