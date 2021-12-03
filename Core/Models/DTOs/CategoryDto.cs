using System.ComponentModel.DataAnnotations;

namespace Core.Models.DTOs
{
    public class CategoryDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
/*
        [MaxLength(255)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string Image { get; set; }
*/
    }
}