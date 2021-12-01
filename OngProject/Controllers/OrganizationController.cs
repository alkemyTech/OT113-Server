using Core.Business.Interfaces;
using Core.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OngProject
{
    [ApiController]
    [Route("organization")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationBusiness _business;

        public OrganizationController(IOrganizationBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route("public/{id}")]
        [ProducesResponseType(typeof(OrganizationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var organization = _business.GetById(id);

                if(organization == null)
                {
                    return NotFound();
                }

                return new JsonResult(organization) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

    }
}
