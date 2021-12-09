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
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public int Phone { get; set; }

        [Required]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Message { get; set; }
    }
}
