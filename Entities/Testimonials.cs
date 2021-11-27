using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Testimonials : EntityBase 
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        [MaxLength(255)]
        public string Image { get; set; }


        [Column(TypeName = "ntext(65535)")]
        public string Content { get; set; }

    }
}
