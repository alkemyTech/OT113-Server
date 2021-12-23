using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.DTOs
{
    public class TestimonailsDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(65535)]
        public string Content { get; set; }
    }
}
