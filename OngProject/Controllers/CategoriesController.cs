using Core.Business.Interfaces;
using Core.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryBusiness _business;

        public CategoriesController(ICategoryBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route("/categories/{id}")]
        public IActionResult GetById(int id)
        {

            var category = _business.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("La categoría buscada no existe");
            }

            return Ok(category);
        }

        [HttpGet]
        [Route("/categories")]
        public async Task<IActionResult> GetAllCategories()
        {

            var categories = await _business.GetAllCategories();

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("~/categories")]
        public IActionResult NewCategory ([FromBody] CategoryDto category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                
                _business.addCategory(category);
                return Ok(category);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }

    }
}