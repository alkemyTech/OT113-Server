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

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
       public IActionResult GetById(int id)
        {
            try
            {
                var news = _business.GetNewsById(id);
                if(news == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.mapNews(news));
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }

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

        [HttpPost("/news")]
        [Authorize(Roles = "Admin")]
        public IActionResult NewsAddItems([FromForm]NewNewsDto newsDto)
        {
            try
            {
                _business.AddNews(newsDto);
                return new JsonResult(newsDto) { StatusCode = 201 };

            }
            catch(Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(NewNewsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

                return new JsonResult(news) {StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

                return new JsonResult(page){ StatusCode = 200 };
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }

    }
}
