using System;
using Entities;
using Repositories;
using Core.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly Repository<User> _repository;

        public UserBusiness(Repository<User> repository)
        {
            _repository = repository;
        }

        
        public void AddUser() { }
        public void RemoveUser(int id) { }
        public void UpdateUser(User user) { }

        public User GetUserById() {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<User>> GetAllUsers() {
            throw new NotImplementedException();
        }
    }

    
}
