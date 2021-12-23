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

        /// GET: /api/Testimonials
        /// <summary>
        /// Returns all testimonials
        /// </summary>
        /// <remarks>
        /// Obtains all the Testimonials. Default amount of objects per page: 10.
        /// </remarks>
        /// <param name="paginationfilter">Pagination filter.</param>
        /// <response code="200">OK. Returns All the Testimonials</response>
        /// <response code="500">Internal server error.</response>
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

        /// POST: /testimonials
        /// <summary>
        /// Adds a new Testimonial.
        /// </summary>
        /// <remarks>
        /// Adds a new Testimonial to the database.
        /// </remarks>
        /// <param name="testimonialsDto">Body of the new Testimonial to be added.</param>
        /// <response code="201">Created. New Testimonial has been succesfully created.
        /// Body of the added Testimonial  will be returned as response.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [Route("/testimonials")]
        [Authorize(Roles = "Admin")]
        public IActionResult TestimonialAddItems([FromForm] TestimonialUpdateDto testimonialsDto)
        {
            try
            {
                return new JsonResult(_business.AddTestimonials(testimonialsDto)) { StatusCode = 201 };

            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }

        }


        /// PUT: /testimonials/1
        /// <summary>
        /// Method to edit a Testimonials given a correct id.
        /// </summary>
        /// <remarks>
        /// Edition of a Testimonials given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the Testimonial.</param>
        /// <param name="updateTestimonial">Testimonial to update</param>
        /// <response code="200">OK. Returns the requested Testimonial.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. A Testimonial with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("~/testimonials/{id}")]
        public IActionResult Update([FromForm] TestimonialUpdateDto updateTestimonial, int id)
        {
            try
            {
                var testimonials = _business.GetTestimonialsById(id);

                if(testimonials == null)
                {
                    return NotFound();
                }

                return Ok(_business.UpdateTestimonials(testimonials, updateTestimonial));
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }

        /// DELETE: /testimonials/1
        /// <summary>
        /// Deletes a Testimonials given a correct id.
        /// </summary>
        /// <remarks>
        /// Deletes a Testimonials given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the Testimonial.</param>
        /// <response code="200">OK. The requested Testimonial was deleted.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. A News with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
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
