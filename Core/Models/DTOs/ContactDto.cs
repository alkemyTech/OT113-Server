using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{
    public class ContactDto
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        [StringLength(320, MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Message { get; set; }
    }
}
