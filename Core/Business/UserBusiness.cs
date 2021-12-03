using System;
using Entities;
using Repositories;
using Core.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helper;
using System.Security.Cryptography;
using Core.Models.DTOs;
using Core.Mapper;

namespace Core.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IRepository<User> _repository;
        private readonly ITokenHandler _tokenHandler;
        private readonly IEntityMapper _mapper;

        public UserBusiness(IRepository<User> repository, ITokenHandler tokenHandler, IEntityMapper mapper)
        {
            _repository = repository;
            _tokenHandler = tokenHandler;
            _mapper = mapper;
        }

        private string EncryptPassSha25(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public async Task<string> Login(UserLoginDto userDto)
        {
            var users = await _repository.GetAll();
            var user = users.SingleOrDefault(user => user.Email == userDto.Email);

            if (user != null)
            {
                if (EncryptPassSha25(userDto.Password) == user.Password)
                {
                    return _tokenHandler.GenerateTokenJWT(_mapper.MapUserLoginDtoToTokenParameter(userDto));
                }
            }

            return null;
        }


        
        public void AddUser() { }
        public void RemoveUser(int id) { }
        public void UpdateUser(User user) { }

        public User GetUserById(int id) 
        {
           return _repository.GetById(id);
        }
        public async Task<IEnumerable<User>> GetAllUsers() {
            throw new NotImplementedException();
        }
    }

    
}
