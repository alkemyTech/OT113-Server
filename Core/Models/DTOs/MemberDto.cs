using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.DTOs
{
    public class MemberDto
    {

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string FacebookUrl { get; set; }

        [MaxLength(255)]
        public string InstagramUrl { get; set; }

        [MaxLength(255)]
        public string LinkedinUrl { get; set; }

        [MaxLength(255)]
        [Required]
        public IFormFile Image { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }


    }
}