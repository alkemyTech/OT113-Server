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


        [HttpGet]
        [Route("/members")]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _business.GetAllMembers();

            if (members == null){
                return NotFound();
            }

            return Ok(members);
        }

        [HttpGet("/memberss")]
        [Authorize(Roles = "User")]
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

        [HttpPut]
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

        [HttpDelete]
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
    }


}
