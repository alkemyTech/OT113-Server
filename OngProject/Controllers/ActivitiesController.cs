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
    [Route("activities")]
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


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ActivitieCreation([FromForm] ActivitiesDto activitiesDto)
        {
            try
            {
                var activity = _business.AddActivity(activitiesDto);

                return new JsonResult(_mapper.mapActityModelToDto(activity)) { StatusCode = 201 };

            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateActivity(int id, [FromForm] ActivityDtoForEdit activityDto){

            var act = _business.getActivity(id);
            if(act == null){
                return NotFound("The activity doesn't  exist");
            }

            else
            _business.UpdateActivity(id, _mapper.MapActivityForEditToActivityDto(activityDto));
            return Ok(_mapper.mapActityModelToDto(act));

        }

        [HttpGet("{id}")]
        public IActionResult GetActivity(int id){

            var activity = _business.GetActivityById(id);
            if(activity == null){
                return NotFound("The activity doesn't  exist");
            }

            return Ok(activity);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllActivities(){

            var activities = await _business.GetAllActivities();

            if(activities == null){
                return NotFound();
            }

            return Ok(activities);
        }

    }
}
