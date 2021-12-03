using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models;
using Core.Models.DTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("auth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _business;
        private readonly IEntityMapper _mapper;
        //private readonly IOptionsMonitor<JwtConfig> _jwtConfig;

        public UsersController(IUserBusiness business, IEntityMapper mapper)
        {
            _business = business;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var userExist = _business.GetAllUsers().Result;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    if (_business.Exist(userExist, user.Email))
                    {
                        return BadRequest("Email existente");
                    }
                    else
                    {
                        _business.AddUser(user);
                        return Ok(_mapper.mapUserDTO(user));
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(400, e);
            }
        }


        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            try
            {
                var token = await _business.Login(user);
                if(token != null)
                {
                    return new JsonResult(new { Token = token }) { StatusCode = 201 };
                }

                return new JsonResult(new { ok = false }) { StatusCode = 201 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

    }
}
