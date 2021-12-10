using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models.DTOs;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {

        private readonly IMembersBusiness _business;

        public MembersController(IMembersBusiness business, IEntityMapper mapper)
        {
            _business = business;

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
        [HttpPost]
        [Route("/members")]
        public IActionResult MemberAddName([FromBody]MembersNameDto memberDto)
        {
            try
            {
                _business.AddMember(memberDto);
                return new JsonResult(memberDto) { StatusCode = 201 };
            
            }catch (Exception e) { return StatusCode(500, $"Hubo un error de tipo {e.Message}"); }
        }
    }


}
