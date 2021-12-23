﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{
    public class SlidesDTO
    {
        public string ImgUrl { get; set; }
        public int Order { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
    }
}
