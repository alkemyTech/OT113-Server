using Core.Business.Interfaces;
using Core.Mapper;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("Slides")]
    public class SlidesController : ControllerBase
    {
        private readonly ISlidesBusiness _business;
        private readonly IEntityMapper _mapper;
        public SlidesController(ISlidesBusiness business, IEntityMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var slides = _business.GetAllSlides().Result;
                var listSlides = _mapper.Mapp(slides);

                return Ok(listSlides);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSlide(int id)
        {
            try
            {
                var slide = _business.FindById(id);
                if(slide == null)
                {
                    return NotFound();
                }

                return Ok(slide);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }


        [HttpDelete]
        [Authorize
        (Roles = "Admin")]
        [Route("/slides/{id}")]
        public IActionResult DeleteSlide(int id){

            var slide = _business.FindById(id);

            if(slide == null || slide.isDelete == true){
                return NotFound("The slide doesn't existe");
            }

            else _business.DeleteSlide(slide);
            return Ok("The Slide was successfully deleted");
        }
    }
}
