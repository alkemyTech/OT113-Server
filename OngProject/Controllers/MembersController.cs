using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Core.Helper;
        
namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMembersBusiness _business;
        private readonly IUriService _uriService;

        public MembersController(IMembersBusiness business, IUriService uriservice)
        {
            _business = business;
            _uriService = uriservice;
        }


        /// GET: /members
        /// <summary>
        /// Returns all members
        /// </summary>
        /// <remarks>
        /// Get all members. Default amount of objects per page: 10.
        /// </remarks>
        /// <param name="filter">Pagination filter.</param>
        /// <response code="200">OK. Returns All the members</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. There is no members.</response>
        [HttpGet("/members")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllMembersP([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var members = await _business.GetAllMembersP(validFilter);
            var totalRecords = _business.CountMembers();
            var pagedResponse = PaginationHelper.CreatePagedReponse<MembersNameDto>(members.ToList(), validFilter, totalRecords, _uriService, route);

            if (members == null) return NotFound();
            else
            {
                return Ok(pagedResponse);
            }
        }

        /// POST: /members
        /// <summary>
        /// Adds a new member.
        /// </summary>
        /// <remarks>
        /// Adds a new member to the database.
        /// </remarks>
        /// <param name="memberDto">Body of the new member to be added.</param>
        /// <response code="201">Created. New member has been succesfully created.
        /// Body of the added member  will be returned as response.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [Route("/members")]
        [Authorize(Roles = "User")]
        public IActionResult MemberAddName([FromBody]MembersNameDto memberDto)
        {
            try
            {
                _business.AddMember(memberDto);
                return new JsonResult(memberDto) { StatusCode = 201 };
            
            }catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }
        }

        /// PUT: /members/1
        /// <summary>
        /// Method to edit a member given a correct id.
        /// </summary>
        /// <remarks>
        /// Edition of a member given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="update">Member to update</param>
        /// <param name="id">Id of the member.</param>
        /// <response code="200">OK. Returns the requested member.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. A member with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut]
        [Authorize(Roles = "User")]
        [Route("~/members/{id}")]
        public IActionResult UpdateMember([FromBody] MemberDto update, int id)
        {
            try
            {
                var member = _business.GetMemberById(id);

                if(member == null)
                {
                    return NotFound();
                }

                _business.UpdateMember(member, update);
                return Ok(update);
            }
            catch(Exception e)
            {
                return StatusCode(400, "Internal error");
            }
        }

        /// DELETE: /member/1
        /// <summary>
        /// Deletes a member given a correct id.
        /// </summary>
        /// <remarks>
        /// Deletes a member given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the member.</param>
        /// <response code="200">OK. The requested member was deleted.</response>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="403">Forbidden. JWT does not correspond to a user with the necessary permissions to perform this action.</response>
        /// <response code="404">NotFound. A member with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete]
        [Authorize(Roles = "User")]
        [Route("~/members/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var member = _business.GetMemberById(id);

                if(member == null)
                {
                    return NotFound();
                }
                _business.RemoveMember(id);

                return Ok("Miembro eliminado correctamente");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }


        /// GET: /members/1
        /// <summary>
        /// Returns a member given a correct id.
        /// </summary>
        /// <remarks>
        /// Obtains a member given a correct Id. An inexistent Id will result in 404 response.
        /// </remarks>
        /// <param name="id">Id of the member.</param>
        /// <response code="401">Unauthorized. JWT is either incorrect or hasn't been submitted.</response>              
        /// <response code="200">OK. Returns the requested member.</response>        
        /// <response code="404">NotFound. A member with the given Id Couldn't be found.</response>
        /// <response code="500">Internal server error.</response>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/members/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var member = _business.GetMember(id);
                if (member == null)
                {
                    return NotFound();
                }
                return Ok(member);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }

    }


}
