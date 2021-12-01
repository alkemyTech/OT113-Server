using System;
using Entities;
using Repositories;
using Core.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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

        public string getSha256(string pass)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            
            return sb.ToString();
        }
    }

    
}
