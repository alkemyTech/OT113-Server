using OT113;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public  class News : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        [Required]
        [MaxLength(255)]
        public string Image { get; set; }


        [Required]
        [Column(TypeName = "ntext(65535)")]

        public string Content { get; set; }


        public Category Category { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
