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



        public UserDto AddUser(UserRegisterDto user) {

            var newUser = _mapper.MapRegisteredUserDtoToUser(user);
            newUser.Password = EncryptPassSha25(newUser.Password);
            _repository.Save(newUser);

            return _mapper.MapUserToUserDto(newUser);
        }
        public User RemoveUser(User user, string token)
        {
            if (UserValidation(token, user))
            {
                _repository.Delete(user.Id);
                return user;
            }
            return null;
        } 

        public User UpdateUsers(User user, UserUpdateDto update, string token)
        {
            if (UserValidation(token, user))
            {
                user.firstName = update.firstName;
                user.lastName = update.lastName;
                user.Photo = update.Photo;
                user.Email = update.Email;
                user.Password = update.Password;
                user.roleId = update.roleId;
                user.modifiedAt = DateTime.Now;
                _repository.Update(user);
                return user;
            }

            return null;
        }

        private bool UserValidation(string token, User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var stringSplit = token.Split(' ');
            var Token = handler.ReadJwtToken(stringSplit[0]);
            var claimsUserId = Token.Claims.Where(x => x.Type == "nameid").FirstOrDefault();
            var userRole = Token.Claims.Where(x => x.Type == "role").FirstOrDefault().Value;
            var id = int.Parse(claimsUserId.Value);

            return (userRole == "Admin" || id == user.roleId);
        }

        public User GetUserById(int id) 
        {
           return _repository.GetById(id);
        }

    }

    
}
