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
        void AddUser(User user);
        void RemoveUser(int id);
        void UpdateUser(User user);
        User GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<string> Login(UserLoginDto userDto);
        bool Exist(IEnumerable<User> users, string email);
    }
}
