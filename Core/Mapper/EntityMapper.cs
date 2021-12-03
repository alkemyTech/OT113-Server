using Abstractions;
using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public interface IEntityMapper
    {
        OrganizationDto Map(Organization organization);

        IEnumerable<CategoryDto> mapCategoriesNamesModelToDto(IEnumerable<Category> categories);
    }

    public class EntityMapper : IEntityMapper
    {
        public OrganizationDto Map(Organization organization)
        {
            if (organization != null)
            {
                var organizationDto = new OrganizationDto
                {
                    Name = organization.Name,
                    Image = organization.Image,
                    Adress = organization.Adress,
                    Phone = organization.Phone,
                    Facebook = organization.Facebook,
                    Linkedin = organization.Linkedin,
                    Instagram = organization.Instagram
                };

                return organizationDto;
            }

            return null;
        }

        public IEnumerable<CategoryDto> mapCategoriesNamesModelToDto(IEnumerable<Category> categories)
        {

            List<CategoryDto> categoriesDto = new List<CategoryDto>();

            if (categories != null)
            {
                foreach (var c in categories)
                {

                    var categoryDTO = new CategoryDto
                    {
                        Name = c.Name
                    };

                    categoriesDto.Add(categoryDTO);
                }

                return categoriesDto;
            }

            return null;

        }
    }
}
