using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Models.DTOs
{
    public class TestimonialUpdateDto
    {
        [Required]
        public string Name { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
