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
using Core.Models;
using Core.Helper;
using Microsoft.AspNetCore.Http;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialsBusiness _business;
        private readonly IUriService _uriService;

        public TestimonialsController(ITestimonialsBusiness business, IUriService uriService)
        {
            _business = business;
            _uriService = uriService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(PagedResponse<List<TestimonailsDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTestimonials([FromQuery] PaginationFilter filter)
        {
            try
            {
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var testimonials = await _business.GetAllTestimonials(validFilter);
                var totalRecords = _business.CountTestimonials();
                var pagedResponse = PaginationHelper.CreatePagedReponse<TestimonailsDto>(testimonials.ToList(), 
                                                                                                   validFilter, 
                                                                                                   totalRecords, 
                                                                                                   _uriService, 
                                                                                                   route);

                return new JsonResult(pagedResponse) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal error");
            }
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
