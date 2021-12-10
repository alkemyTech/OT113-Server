using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{

    public class NewNewsDto
    {
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "news")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [Column(TypeName = "news")]
        public string Image { get; set; }

        [Required]
        [MaxLength(65535)]
        [Column(TypeName = "news")]
        public string Content { get; set; }

        [Column(TypeName = "news")]
        [Required]
        public int CategoryId { get; set; }

        //[Column(TypeName = "news")]
        //public Category Category { get; set; }


    }
}
