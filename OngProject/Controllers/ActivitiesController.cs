using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models;
using Core.Models.DTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Services;
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

        /// <summary>
        /// Endopoint for Activities.
        /// </summary>
        public ActivitiesController(IActivityBusiness business, IEntityMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        /// POST: /Activities2
        /// <summary>
        /// Create a new activitie.
        /// </summary>
        /// <remarks>
        /// Add a new activite to our DB.
        /// </remarks>
        /// <param name="activitiesDto"></param>
        /// <response code ="201">Created. The new Activitie was created succefully.</response>
        /// <response code ="400">BadRequest. The activitie  was not created.</response>
        /// <response code="401">Unauthorize. JWT Token is incorrect or it´s empty.</response>
        /// <response code="403">Forbiden. JWT token doesn´t correspond to a user.</response>
        /// <response code ="500">Internal Server Error.</response>
        /// <returns></returns>
        [HttpPost]      
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActivitieCreation([FromForm] ActivitiesDto activitiesDto)
        {
            try
            {
                var activity = _business.AddActivity(activitiesDto);

                return new JsonResult(_mapper.mapActityModelToDto(activity)) { StatusCode = 201 };

            }
            catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }

        }

        /// PUT: /activities
        /// <summary>
        /// Method to update a activitie with the id of one of them.
        /// </summary>
        /// <remarks>
        /// To edit or update a activite alrready created with the Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="activityDto"></param>
        /// <response code ="200">Ok. Return the activitie requested.</response>
        /// <response code="401">Unauthorize. JWT Token is incorrect or it´s empty.</response>
        /// <response code="403">Forbiden. JWT token doesn´t correspond to a user.</response>
        /// <response code ="404">NotFound. The id of activitie gived was not found.</response>
        /// <response code ="500">Internal Server Error.</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateActivity(int id, [FromForm] ActivityDtoForEdit activityDto){

            var act = _business.getActivity(id);
            if(act == null){
                return NotFound("The activity doesn't  exist");
            }

            else
            _business.UpdateActivity(id, _mapper.MapActivityForEditToActivityDto(activityDto));
            return Ok(_mapper.mapActityModelToDto(act));

        }

        /// GET: /activities/1
        /// <summary>
        /// To find a especially activitie with the id.
        /// </summary>
        /// <remarks>
        /// If the Id of activite doesn´t found will be response with 404.
        /// </remarks>
        /// <param name="id"></param>
        /// <response code ="200">Ok. Return the activitie requested.</response>
        /// <response code="401">Unauthorize. JWT Token is incorrect or it´s empty.</response>
        /// <response code="403">Forbiden. JWT token doesn´t correspond to a user.</response>
        /// <response code ="404">NotFound. The id of activitie gived was not found.</response>      
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public IActionResult GetActivity(int id){

            var activity = _business.GetActivityById(id);
            if(activity == null){
                return NotFound("The activity doesn't  exist");
            }

            return Ok(activity);
        }

        /// GET: /activities/1
        /// <summary>
        /// Get a lot of activites.
        /// </summary>
        /// <remarks>
        /// List all the activities.
        /// </remarks>
        /// <response code ="200">Ok. Return the activitie requested.</response>
        /// <response code="401">Unauthorize. JWT Token is incorrect or it´s empty.</response>
        /// <response code="403">Forbiden. JWT token doesn´t correspond to a user.</response>
        /// <response code ="404">NotFound. The id of activitie gived was not found.</response>       
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllActivities(){

            var activities = await _business.GetAllActivities();

            if(activities == null){
                return NotFound();
            }

            return Ok(activities);
        }

    }
}
