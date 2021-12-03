﻿using Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TokenParameter : ITokenParameter
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
