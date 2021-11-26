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

        public NewsBusiness(Repository<User> repository)
        {
            _repository = repository;
        }

        
        public void AddUser() { }
        public void RemoveUser(int id) { }
        public void UpdateUser(News news) { }

        public User GetUserById() { }
        public async Task<IEnumerable<User>> GetAllUsers() { }
    }

    }
}
