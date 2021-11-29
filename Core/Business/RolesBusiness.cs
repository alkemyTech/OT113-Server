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
    public class RolesBusiness : IActivityBusiness
    {
        private readonly IRepository<Roles> _roles;

        public RolesBusiness(IRepository<Roles> repository)
        {
            _roles = repository;
        }

        public Organization GetRolesById()
        {
            throw new NotImplementedException();
        }
        public async Task <IEnumerable<Roles>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public void UpdateRoles(Roles roles) {  }

        public void DeleteRoles(int id) { }

        public void InsertRoles() { }
    }
}
