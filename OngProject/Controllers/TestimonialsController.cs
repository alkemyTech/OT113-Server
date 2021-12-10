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

        [HttpPost("testimonials")]
        //[Authorize(Roles = "Admin")]
        public IActionResult TestimonialAddItems([FromBody]TestimonailsDto testimonialsDto)
        {
            try
            {
                _business.AddTestimonials(testimonialsDto);
                return new JsonResult(testimonialsDto) { StatusCode = 201 };

            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }

        }

    }
}
