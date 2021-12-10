using Core.Business.Interfaces;
using Core.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsBusiness _business;
        private readonly SendGInterface _emailService;

        public ContactsController(IContactsBusiness business, SendGInterface emailService)
        {
            _business = business;
            _emailService = emailService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ContactDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                var contacts = await _business.GetAllContacts();
                return new JsonResult(contacts) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddContact([FromBody]ContactDto contact)
        {
            try
            {
                _business.AddContact(contact);
                _emailService.SendEmailAsync(contact.Email, $"Gracias por contactarnos {contact.Name} ", "Comprobante de contacto").Wait();

                return new JsonResult(contact) { StatusCode = 201 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }
    }
}
