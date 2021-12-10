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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IRepository<User> _repository;
        private readonly ITokenHandler _tokenHandler;
        private readonly IEntityMapper _mapper;
        private readonly IRepository<Roles> _roleRepository;

        public UserBusiness(IRepository<User> repository, ITokenHandler tokenHandler, IEntityMapper mapper, IRepository<Roles> roleRepository)
        {
            _repository = repository;
            _tokenHandler = tokenHandler;
            _mapper = mapper;
            _roleRepository = roleRepository;
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

        private int GetUserId(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var stringSplit = token.Split(' ');
            var Token = handler.ReadJwtToken(stringSplit[0]);
            var claims = Token.Claims.Where(x => x.Type == "nameid").FirstOrDefault();
            var id = int.Parse(claims.Value);
            return id;
        }

        public UserDetailsDto GetUserDetails(string token)
        {
            var id = GetUserId(token);
            var user = _repository.GetById(id);

            return new UserDetailsDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = _roleRepository.GetById(user.roleId).Name
            };
        }

        public async Task<string> Login(UserLoginDto userDto)
        {
            var users = await _repository.GetAll();
            var user = users.SingleOrDefault(user => user.Email == userDto.Email);

            if (user != null)
            {
                var role = _roleRepository.GetById(user.roleId).Name;
                var tokenParameter = _mapper.MapUserLoginDtoToTokenParameter(userDto);
                tokenParameter.Role = role;
                tokenParameter.Id = user.Id;
                if (EncryptPassSha25(userDto.Password) == user.Password)
                {
                    return _tokenHandler.GenerateTokenJWT(tokenParameter);
                }
            }

            return null;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _repository.GetAll();

            return users;
        }

        public bool Exist(IEnumerable<User> users, string email)
        {
            var exist = users.Where(user => user.Email == email).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }

            return false;
        }



        public void AddUser(UserRegisterDto user) {
            User newUser = new User
            {
                firstName = user.firstName,
                lastName = user.lastName,
                Email = user.Email,
                Password = EncryptPassSha25(user.Password),
                Photo = user.Photo,
                roleId = 1,
                isDelete = false,
                modifiedAt = DateTime.Now
            };

            _repository.Save(newUser);
        }
        public void RemoveUser(int id) { }
        public void UpdateUser(User user) { }

        public User GetUserById(int id) 
        {
           return _repository.GetById(id);
        }
    }

    
}
