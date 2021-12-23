using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Models.DTOs
{
    public class TestimonialDtoResponse
    {
        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
