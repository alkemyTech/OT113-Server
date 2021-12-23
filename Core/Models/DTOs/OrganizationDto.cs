using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{
    public class OrganizationDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Image { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Facebook { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Linkedin { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Instagram { get; set; }

        public List<SlidesDTO> Slides {get;set;}

    }
}
