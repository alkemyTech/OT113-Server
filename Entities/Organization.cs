using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Organization : EntityBase
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
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        public string WelcomeText { get; set; }

        [MaxLength(2000)]
        public string AboutUsText { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Facebook { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Linkedin { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Instagram { get; set; }
    }
}
