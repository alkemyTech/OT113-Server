using Core.Business.Interfaces;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class OrganizationBusiness : IOrganizationBusiness
    {
        private readonly IRepository<Organization> _organization;

        public OrganizationBusiness (IRepository<Organization> repository)
        {
            _organization = repository;
        }

        public Organization GetOrganizationById()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Organization>> GetAllOrganization()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrganization(Organization context) { }

        public void DeleteOrganization(int id) { }

        public void InsertOrganization() { }
    }
}
