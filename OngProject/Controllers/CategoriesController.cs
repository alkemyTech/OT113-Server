using Core.Business.Interfaces;
using Core.Helper;
using Core.Models.DTOs;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryBusiness _business;
        private readonly IUriService _uriService;

        ///<Summary>
        /// Endpoint for categories
        ///</Summary>
        public CategoriesController(ICategoryBusiness business, IUriService uriService)
        {
            _business = business;
            _uriService = uriService;
        }


        /// GET: /categories/1
        /// <summary>
        /// Returns a category given a correct id.
        /// </summary>
        /// <remarks>
        /// Obtains a category given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the category.</param>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="200">OK. Returns the requested category.</response>        
        /// <response code="404">NotFound. A category with the given Id Couldn't be found.</response>
        [HttpGet]
        [Route("/categories/{id}")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {

            var category = _business.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("La categoría buscada no existe");
            }

            return Ok(category);
        }

        /// GET: /categories
        /// <summary>
        /// Returns all categories
        /// </summary>
        /// <remarks>
        /// Obtains all the categories. Default amount of objects per page: 10.
        /// </remarks>
        /// <param name="filter">Pagination filter.</param>
        /// <response code="200">OK. Returns All the categories</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>                      
        /// <response code="404">NotFound. A category with the given Id Couldn't be found.</response>
        [HttpGet]
        [Authorize]
        [Route("/categories")]
        [ProducesResponseType(typeof(PagedResponse<List<CategoryDtoGetAllResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllCategories([FromQuery] PaginationFilter filter)
        {

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var categories = await _business.GetAllCategories(validFilter);
            var totalRecords = _business.CountCategories();
            var pagedResponse = PaginationHelper.CreatePagedReponse<CategoryDtoGetAllResponse>(categories.ToList(),
                                                                                               validFilter,
                                                                                               totalRecords,
                                                                                               _uriService,
                                                                                               route);

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(pagedResponse);
        }

        /// POST: /categories
        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <remarks>
        /// Adds a new category to the database.
        /// </remarks>
        /// <param name="category">Body of the new category to be added.</param>
        /// <response code="201">Created. New category has been succesfully created.
        /// Body of the added category will be returned as response.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [Route("~/categories")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult NewCategory([FromForm] CategoryDtoPostRequest category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                ;
                
                return new JsonResult(_business.addCategory(category)) { StatusCode = 201};
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }


        /// PUT: /categories/1
        /// <summary>
        /// Method to edit a category given a correct id.
        /// </summary>
        /// <remarks>
        /// Edition of a category given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the category.</param>
        /// <param name="updateCategories">Category to update</param>
        /// <response code="200">OK. Returns the requested category.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. A category with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("/categories/{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCategories([FromForm] CategoryDtoPostRequest updateCategories, int id)
        {
            try
            {
                var categories = _business.GetCategoryById2(id);

                if (categories == null) return NotFound("The category doesn't exist");
                else
                {
                    _business.UpdateCategory(categories, updateCategories);
                    return Ok("The category was update.");
                }

            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }
        }


        /// DELETE: /categories/1
        /// <summary>
        /// Deletes a category given a correct id.
        /// </summary>
        /// <remarks>
        /// Deletes a category given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the category.</param>
        /// <response code="200">OK. Returns the requested category.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. A category with the given Id Couldn't be found.</response>
        [HttpDelete("/categories/{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var categorie = _business.GetCategoryById2(id);

                if (categorie == null)
                {
                    return NotFound("The category doesn't exist");
                }
                else
                {
                    _business.DeleteCategorie(categorie);
                    return Ok("The category has been removed successfully.");
                }


            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }

        }

    }
    
}