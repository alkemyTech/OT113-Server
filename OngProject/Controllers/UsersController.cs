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
    [Route("user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _business;

        public UsersController(IUserBusiness business)
        {
            _business = business;
        }
        [HttpPost("auth/register")]
        public IActionResult Register([FromBody] User user)
        {
            if(!String.IsNullOrWhiteSpace(user.firstName) && String.IsNullOrWhiteSpace(user.lastName) && String.IsNullOrWhiteSpace(user.Email) && String.IsNullOrWhiteSpace(user.Password))
            {
                return StatusCode(400, "Error al validar los campos");
            }
            else
            {
                try
                {

                    //SHA256 sha256 = SHA256Managed.Create();
                    //ASCIIEncoding encoding = new ASCIIEncoding();
                    //byte[] stream = null;
                    //StringBuilder sb = new StringBuilder();
                    //stream = sha256.ComputeHash(encoding.GetBytes(user.Password));
                    //for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);

                    User newUser = new User
                    {
                        firstName = user.firstName,
                        lastName = user.lastName,
                        Email = user.Email,
                        Password = _business.getSha256(user.Password)
                };
                    return Ok(newUser);
                }
                catch (Exception e)
                {
                    return StatusCode(400, e);
                }
            }
        }
    }
}
