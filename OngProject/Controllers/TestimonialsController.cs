using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Repositories;
using Core.Business.Interfaces;
using Core.Models.DTOs;
using Core.Mapper;
using Microsoft.AspNetCore.Authorization;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialsBusiness _business;

        public TestimonialsController(ITestimonialsBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        [Route("/testimonials")]
        [Authorize(Roles = "Admin")]
        public IActionResult TestimonialAddItems([FromBody]TestimonailsDto testimonialsDto)
        {
            try
            {
                _business.AddTestimonials(testimonialsDto);
                return new JsonResult(testimonialsDto) { StatusCode = 201 };

            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }

        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("~/testimonials/{id}")]
        public IActionResult Update([FromBody] TestimonialUpdateDto updateTestimonial, int id)
        {
            try
            {
                var testimonials = _business.GetTestimonialsById(id);

                if(testimonials == null)
                {
                    return NotFound();
                }

                _business.UpdateTestimonials(testimonials, updateTestimonial);

                return Ok(updateTestimonial);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("~/testimonials/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var testimonial = _business.GetTestimonialsById(id);

                if(testimonial == null)
                {
                    return NotFound();
                }

                _business.RemoveTestimonials(id);
                return Ok("Testimonio eliminado con éxito");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }
    }
}
