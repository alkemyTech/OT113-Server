using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Member
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string FacebookUrl { get; set; }

        [StringLength(255)]
        public string InstagramUrl { get; set; }

        [StringLength(255)]
        public string LinkedinUrl { get; set; }

        [StringLength(255)]
        [Required]
        public string Image { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
