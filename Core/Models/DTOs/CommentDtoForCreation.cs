using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{
    public class CommentDtoForCreation
    {
        [Required]
        public int userId { get; set; }

        [Required]
        [MinLength(1)]
        public string Body { get; set; }

        [Required]
        public int newsId { get; set; }
    }
}
