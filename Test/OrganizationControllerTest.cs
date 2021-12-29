using Core.Business.Interfaces;
using Core.Models.DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Test.Helper;

namespace Test
{
    [TestClass]
    public class OrganizationControllerTest
    {
        private readonly OrganizationController _controller;
        private readonly IOrganizationBusiness _business;

     
        public OrganizationControllerTest()
        {
            _business = new OrganizationBusinessTest();
            _controller = new OrganizationController(_business);
        }

        [TestMethod]
        public void GetById_ExistinOrgPassed_ReturnsOkResult()
        {
           
            var id = 1;

            var response = _controller.GetById(id);

            Assert.IsNotNull(response);
            
        }

        [TestMethod]
        public void GetById_NonExistinOrgPassed_ReturnsNull()
        {

            var id = 5;

            var response = _controller.GetById(id);

            Assert.IsNull(response as JsonResult);
        }

        [TestMethod]
        public void Update_ExistinOrgPassed_ReturnsOkResult()
        {

            var orgDto = new OrganizationDtoPostRequest();
            orgDto.Id = 1;
            orgDto.Name = "TestOrg1 MOD";
            orgDto.Image = "Image\\Captura1.png";
            orgDto.Address = "testAdressOrg1 MOD";
            orgDto.Phone = "0303456nanana";
            orgDto.Email = "MOD@testOrg1.com";
            orgDto.WelcomeText = "welcome text org test 1 MOD";
            orgDto.AboutUsText = "about us text org test 1 MOD";
            orgDto.Facebook = "www.facebook.com/testOrg1";
            orgDto.Linkedin = "www.linkedin.com/testOrg1";
            orgDto.Instagram = "www.instagram.com/testOrg1";

           
            var okResult = _controller.updateOrganization(orgDto) as ObjectResult;

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void Update_NonExistinOrgPassed_ReturnsNull()
        {

            var orgDto = new OrganizationDtoPostRequest();
            orgDto.Id = 22;
            orgDto.Name = "TestOrg1 MOD";
            orgDto.Image = "Image\\Captura1.png";
            orgDto.Address = "testAdressOrg1 MOD";
            orgDto.Phone = "0303456nanana";
            orgDto.Email = "MOD@testOrg1.com";
            orgDto.WelcomeText = "welcome text org test 1 MOD";
            orgDto.AboutUsText = "about us text org test 1 MOD";
            orgDto.Facebook = "www.facebook.com/testOrg1";
            orgDto.Linkedin = "www.linkedin.com/testOrg1";
            orgDto.Instagram = "www.instagram.com/testOrg1";

            var okResult = _controller.updateOrganization(orgDto);

            Assert.IsNull(okResult as JsonResult);
        }

    
    }
}
