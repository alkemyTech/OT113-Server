using Core.Business.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("auth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _business;

        public UsersController(IUserBusiness business)
        {
            _business = business;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var userExist = _business.GetAllUsers().Result;
            User newUser = new User();
            try
            {
                if (!String.IsNullOrWhiteSpace(user.firstName) && String.IsNullOrWhiteSpace(user.lastName) && String.IsNullOrWhiteSpace(user.Email) && String.IsNullOrWhiteSpace(user.Password))
                {
                    return StatusCode(400, "Error al validar los campos");
                }
                else
                {
                    foreach( var users in userExist){
                        if(users.Email == user.Email)
                        {
                            return StatusCode(500, "Usuario existente");
                        }
                        newUser = new User
                        {
                            firstName = user.firstName,
                            lastName = user.lastName,
                            Email = user.Email,
                            Password = _business.getSha256(user.Password)
                        };
                    }
                    return Ok(newUser);
                }
            }
            catch(Exception e)
            {
                return StatusCode(400, e);
            }
        }
    }
}

