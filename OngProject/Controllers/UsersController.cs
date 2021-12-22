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
    [Route("auth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _business;
        private readonly IEntityMapper _mapper;
        private readonly SendGInterface _sendG;

        /// <summary>
        /// Endpoint for Users.
        /// </summary>
        public UsersController(IUserBusiness business, IEntityMapper mapper, SendGInterface sendGBusiness)
        {
            _business = business;
            _mapper = mapper;
            _sendG = sendGBusiness;
        }

        /// POST: /Users
        /// <summary> Create a new User. </summary>
        /// <remarks> Add a new User to our DataBase. </remarks>
        /// <param name="user"></param>
        /// <response code = "201"> Created. The new User has arrived! </response>
        /// <response code = "400"> BadRequest. The user was not created. </response>
        /// <response code = "401"> Unauthorize. JWT Token is incorrect or it´s empty. </response>
        /// <response code = "403"> Forbiden. JET Token doesn´t correspond to a level "user".</response>
        /// <response code = "500"> Internal Server Error.</response>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Register([FromForm] UserRegisterDto user)
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
                        var response = _business.AddUser(user);
                        _sendG.SendEmailAsync(user.Email, $"Gracias por registrarte {user.firstName} {user.lastName}", "Registro completo").Wait();
                        return Ok(response);
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(400, e);
            }
        }

        /// POST: /Users2
        /// <summary> Login in our system. </summary>
        /// <remarks> It´s need to be logged to use ours methods. </remarks>
        /// <param name="user"></param>
        /// <response code = "201"> Created. The new User has arrived! </response>
        /// <response code = "400"> BadRequest. The user was not created. </response>
        /// <response code = "401"> Unauthorize. JWT Token is incorrect or it´s empty. </response>
        /// <response code = "403"> Forbiden. JET Token doesn´t correspond to a level "user".</response>
        /// <response code = "500"> Internal Server Error.</response>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
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

        /// GET: /Users
        /// <summary> Authentication. </summary>
        /// <remarks> Shows the basic information and role of the logged user. </remarks>
        /// <response code = "200"> Ok. Return the User requested. </response>
        /// <response code = "401"> Unauthorize. JWT Token is incorrect or it´s empty. </response>
        /// <response code = "403"> Forbiden. JET Token doesn´t correspond to a level "user".</response>
        /// <response code = "404"> NotFound. The id of user gived was not found.</response>
        /// <returns></returns>
        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(typeof(List<UserDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserDetailsFromToken()
        {
            try
            {
                var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

                return new JsonResult(_business.GetUserDetails(token)) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        /// GET: /Users
        /// <summary> Show the users basic informataion. </summary>
        /// <remarks> List a lot of users information. </remarks>
        /// <response code = "200"> Ok. Return the User requested. </response>
        /// <response code = "401"> Unauthorize. JWT Token is incorrect or it´s empty. </response>
        /// <response code = "403"> Forbiden. JET Token doesn´t correspond to a level "user".</response>
        /// <response code = "404"> NotFound. The id of user gived was not found.</response>
        /// <returns></returns>
        [HttpGet]
        [Route("~/users")]
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _business.GetAllUsers().Result;

                return Ok(_mapper.mapUsers(users));
            }
            catch(Exception e)
            {
                return StatusCode(400, e);
            }
        }

        /// DELETE: /users
        /// <summary>
        /// Deletes the User given the righ one ID.
        /// </summary>
        /// <remarks> If the id is incorrect or does not exist will retur a 404 error.</remarks>
        /// <param name="id"></param>
        /// <response code = "200"> Ok. Return the User requested. </response>
        /// <response code = "401"> Unauthorize. JWT Token is incorrect or it´s empty. </response>
        /// <response code = "403"> Forbiden. JET Token doesn´t correspond to a level "user".</response>
        /// <response code = "404"> NotFound. The id of user gived was not found.</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _business.GetUserById(id);
                var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
               
                if (user == null) return NotFound("User does not exist");
                else
                {
                    _business.RemoveUser(user, token);
                    return Ok("User has been removed correctly");
                }
            }
            catch (Exception e) { return StatusCode(500, $"There´s was an error of type: {e.Message}"); };
        }

    }
}
