using System.ComponentModel.DataAnnotations;


namespace Core.Models.DTOs
{
    public class CategoryDtoGetAllResponse
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}