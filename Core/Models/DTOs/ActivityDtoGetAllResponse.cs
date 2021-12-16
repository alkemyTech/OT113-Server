using System.ComponentModel.DataAnnotations;

namespace Core.Models.DTOs
{
    public class ActivityDtoGetAllResponse
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}