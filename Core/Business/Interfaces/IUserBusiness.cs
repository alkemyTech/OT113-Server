﻿using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface IUserBusiness
    {
        void AddUser(UserRegisterDto user);
        User RemoveUser(User user);
        void UpdateUser(User user);
        User GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<string> Login(UserLoginDto userDto);
        bool Exist(IEnumerable<User> users, string email);
        UserDetailsDto GetUserDetails(string token);
        User GetUserId(int id);
    }
}
