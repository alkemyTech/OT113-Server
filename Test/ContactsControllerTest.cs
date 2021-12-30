using Core.Business.Interfaces;
using Core.Models.DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OngProject.Controllers;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class ContactsControllerTest
    {

        [TestMethod]
        public async Task GetAll()
        {
            Mock<IContactsBusiness> contactsBusiness = new Mock<IContactsBusiness>();
            Mock<SendGInterface> email = new Mock<SendGInterface>();

            var controller = new ContactsController(contactsBusiness.Object, email.Object);

            var response = await controller.GetAllContacts();
            Assert.AreEqual(typeof(JsonResult), response.GetType());
        }

        [TestMethod]
        public void NewContact()
        {
            var newContact = new ContactDto
            {
                Name = "Ramón",
                Phone = 123,
                Email = "ram@example.com",
                Message = "Hola"
            };

            Mock<IContactsBusiness> contactsBusiness = new Mock<IContactsBusiness>();
            Mock<SendGInterface> email = new Mock<SendGInterface>();

            var controller = new ContactsController(contactsBusiness.Object, email.Object);

            var response = controller.AddContact(newContact);

            Assert.AreEqual(typeof(JsonResult), response.GetType());
        }
    }
}
