﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SendGrid
    {
        private IConfiguration _configuration;
        public SendGrid(IConfiguration configuration,)
        {
            _configuration = configuration;
        }
    }
}
