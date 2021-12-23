using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface IOrganizationBusiness
    {
        OrganizationDto GetById(int id);

        void UpdateOrganization(OrganizationDtoPostRequest organization);

        Organization GetOrg(int id);
    }
}
