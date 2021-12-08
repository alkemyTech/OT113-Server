using Core.Business.Interfaces;
using Core.Mapper;
using Microsoft.AspNetCore.Authorization;
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

        public NewsController(INewsBusiness business, IEntityMapper mapper)
        {
            _business = business;
            _mapper = mapper;
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
    }
}
