using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    class Organization : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Image { get; set; }

        [MaxLength(255)]
        public string Adress { get; set; }

        [Phone]
        [MaxLength(20)]
        public int Phone { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        public string WelcomeText { get; set; }

        [MaxLength(2000)]
        public string AboutUsText { get; set; }
    }
}
