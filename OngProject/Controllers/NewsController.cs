using Core.Business.Interfaces;
using Core.Helper;
using Core.Mapper;
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
    [Route("news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsBusiness _business;
        private readonly IEntityMapper _mapper;
        private readonly ICommentBusiness _commentBusiness;
        private readonly IUriService _uriService;

        public NewsController(INewsBusiness business, IEntityMapper mapper, ICommentBusiness commentBusiness, IUriService uriService)
        {
            _business = business;
            _mapper = mapper;
            _commentBusiness = commentBusiness;
            _uriService = uriService;
        }

        /// GET: /news/1
        /// <summary>
        /// Returns a News given a correct id.
        /// </summary>
        /// <remarks>
        /// Obtains a News given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the News.</param>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="200">OK. Returns the requested News.</response>        
        /// <response code="404">NotFound. A News with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var news = _business.GetNewsById(id);
                if (news == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.mapNews(news));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }


        /// GET: /news/{id}/comments
        /// <summary>
        /// Returns all comments of a News given a correct id.
        /// </summary>
        /// <remarks>
        /// Obtains every comments posted on a News given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the News.</param>             
        /// <response code="200">OK. Returns all the comments of the News.</response>        
        /// <response code="404">NotFound. A News with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}/comments")]
        public IActionResult GetComments(int id)
        {
            try
            {
                var news = _business.GetNewsById(id);

                if (news == null)
                {
                    return NotFound();
                }

                var comments = _business.GetCommentByNews(id);
                return Ok(comments);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }

        /// POST: /news
        /// <summary>
        /// Adds a new News.
        /// </summary>
        /// <remarks>
        /// Adds a new News to the database.
        /// </remarks>
        /// <param name="newsDto">Body of the new News to be added.</param>
        /// <response code="201">Created. New News has been succesfully created.
        /// Body of the added News  will be returned as response.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("/news")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(NewNewsDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult NewsAddItems([FromForm] NewNewsDto newsDto)
        {
            try
            {
                _business.AddNews(newsDto);
                return new JsonResult(newsDto) { StatusCode = 201 };

            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }
        }


        /// PUT: /news/1
        /// <summary>
        /// Method to edit a News given a correct id.
        /// </summary>
        /// <remarks>
        /// Edition of a News given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the News.</param>
        /// <param name="news">News to update</param>
        /// <response code="200">OK. Returns the requested News.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. A News with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(NewNewsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateNews(int id, [FromForm] NewNewsDto news)
        {
            try
            {
                var newsEntity = _business.GetNewsById(id);

                if (newsEntity == null)
                {
                    return NotFound();
                }

                _business.UpdateNews(newsEntity, news);

                return new JsonResult(news) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        /// DELETE: /news/1
        /// <summary>
        /// Deletes a News given a correct id.
        /// </summary>
        /// <remarks>
        /// Deletes a News given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the News.</param>
        /// <response code="204">OK. The requested News was deleted.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. A News with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteNews(int id)
        {
            try
            {
                var newsEntity = _business.GetNewsById(id);

                if (newsEntity == null)
                {
                    return NotFound();
                }

                _business.DeleteNews(newsEntity);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        /// GET: /news
        /// <summary>
        /// Returns all the News
        /// </summary>
        /// <remarks>
        /// Obtains all the News. Default amount of objects per page: 10.
        /// </remarks>
        /// <param name="paginationfilter">Pagination filter.</param>
        /// <response code="200">OK. Returns All the News</response>
        /// <response code="404">NotFound. There is no News.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllNews([FromQuery] PaginationFilter paginationfilter)
        {
            try
            {
                var route = Request.Path.Value;
                var filter = new PaginationFilter(paginationfilter.PageNumber, paginationfilter.PageSize);
                var news = await _business.GetAllNews(filter);
                var total = _business.CountNews();

                var page = PaginationHelper.CreatePagedReponse<NewsDto>(news.ToList(), filter, total, _uriService, route);


                if (news == null)
                {
                    return NotFound();
                }

                return new JsonResult(page) { StatusCode = 200 };

            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }

    }
}
