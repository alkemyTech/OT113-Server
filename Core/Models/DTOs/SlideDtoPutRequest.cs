using System.ComponentModel.DataAnnotations;

namespace Core.Models.DTOs
{
    public class SlideDtoPutRequest
    {
        [Required]
        public string ImgUrl { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Order { get; set; }
    }
}