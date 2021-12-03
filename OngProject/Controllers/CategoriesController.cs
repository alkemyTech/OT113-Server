using Core.Business.Interfaces;
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

    }
}