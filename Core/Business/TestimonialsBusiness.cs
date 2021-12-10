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
namespace Core.Business
{
   public class TestimonialsBusiness : ITestimonialsBusiness
    {
        
        private readonly Repository<Testimonials> _repository;
        private readonly IEntityMapper _mapper;
            

        public TestimonialsBusiness(Repository<Testimonials> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddTestimonials(TestimonailsDto testimonial) 
        {
            var testimonialMapped = _mapper.TestimonialsMapDto(testimonial);
            _repository.Save(testimonialMapped);
        }

        public void RemoveTestimonials(int id) { }
        public void UpdateTestimonials(Testimonials testimonials) { }
        public Testimonials GetTestimonialsById() { throw new NotImplementedException(); }
        public async Task<IEnumerable<Testimonials>> GetAllTestimonials() { throw new NotImplementedException(); }
     }
 }

