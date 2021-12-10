using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models;
using Core.Models.DTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityBusiness _business;
        private readonly IEntityMapper _mapper;

        public ActivitiesController(IActivityBusiness business, IEntityMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }


        [HttpPost("activities")]
        //[Authorize(Roles = "Admin")]
        public IActionResult ActivitieCreation([FromBody] ActivitiesDto activitiesDto)
        {
            try
            {
                _business.AddActivity(activitiesDto);
                return new JsonResult(activitiesDto) { StatusCode = 201 };

            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }

        }

    }
}
