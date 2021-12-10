using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.DTOs
{
    public class ActivitiesDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        [Required]
        [MaxLength(255)]
        public string Image { get; set; }
    }
}
