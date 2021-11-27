using Core.Business.Interfaces;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
   public class TestimonialsBusiness : ITestimonialsBusiness
    {
        
            private readonly Repository<Testimonials> _repository;

            public TestimonialsBusiness(Repository<Testimonials> repository)
            {
                _repository = repository;
            }

            public void AddTestimonials() { }
            public void RemoveTestimonials(int id) { }
            public void UpdateTestimonials(Testimonials testimonials) { }
            public Testimonials GetTestimonialsById() { throw new NotImplementedException(); }
            public async Task<IEnumerable<Testimonials>> GetAllTestimonials() { throw new NotImplementedException(); }
     }
 }

