using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Helper
{
    class OrganizationBusinessTest : IOrganizationBusiness
    {
        private const string img = "Image\\Captura1.png";
        private readonly List<Organization> _organizations;

        public OrganizationBusinessTest()
        {
 
            _organizations = new List<Organization>()
            {
                new Organization() {
                    Id = 1, 
                    Name = "TestOrg1",
                    Image = img,
                    Address = "testAdressOrg1",
                    Phone = "0303456nanana",
                    Email = "test@testOrg1.com",
                    WelcomeText = "welcome text org test 1",
                    AboutUsText = "about us text org test 1",
                    Facebook = "www.facebook.com/testOrg1",
                    Linkedin = "www.linkedin.com/testOrg1",
                    Instagram = "www.instagram.com/testOrg1",
                    isDelete = false,
                    modifiedAt = DateTime.Now
                },
                new Organization() {
                    Id = 2,
                    Name = "TestOrg2",
                    Image = "",
                    Address = "testAdressOrg2",
                    Phone = "0303456nanana2",
                    Email = "test@testOrg2.com",
                    WelcomeText = "welcome text org test 2",
                    AboutUsText = "about us text org test 2",
                    Facebook = "www.facebook.com/testOrg2",
                    Linkedin = "www.linkedin.com/testOrg2",
                    Instagram = "www.instagram.com/testOrg2",
                    isDelete = true,
                    modifiedAt = DateTime.Now
                }
            };
        }

        public OrganizationDto GetById(int id)
        {
            
             var organization = _organizations.Where(o => o.Id == id).FirstOrDefault();

            if (organization != null)
            {
                var organizationDto = new OrganizationDto
                {
                    Name = organization.Name,
                    Image = organization.Image,
                    Address = organization.Address,
                    Phone = organization.Phone,
                    Facebook = organization.Facebook,
                    Linkedin = organization.Linkedin,
                    Instagram = organization.Instagram,
                    Slides = new List<SlidesDTO>()
                };

                return organizationDto;
            }
           
            return null;
            
        }

        public Organization GetOrg(int id)
        {
            var organization = _organizations.Where(o => o.Id == id).FirstOrDefault();

            if (organization != null)
            {
                return organization;
            }

            return null;

        }

        public void UpdateOrganization(OrganizationDtoPostRequest organization)
        {
          
            var organizationEdit = GetOrg(organization.Id);
            var organizationRemove = organizationEdit;
            _organizations.Remove(organizationRemove);

            organizationEdit.Name = organization.Name;
            organizationEdit.Image = organization.Image;
            organizationEdit.Address = organization.Address;
            organizationEdit.Phone = organization.Phone;
            organizationEdit.Facebook = organization.Facebook;
            organizationEdit.Linkedin = organization.Linkedin;
            organizationEdit.Instagram = organization.Instagram;
            organizationEdit.WelcomeText = organization.WelcomeText;
            organizationEdit.AboutUsText = organization.AboutUsText;
            organizationEdit.isDelete = false;
            organizationEdit.modifiedAt = DateTime.Now;

            _organizations.Add(organizationEdit);
           
        }
    }
}
