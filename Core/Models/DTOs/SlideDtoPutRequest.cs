using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.DTOs
{
    public class SlideDtoPutRequest
    {
        public IFormFile ImgUrl { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Order { get; set; }
        public int OrganizationId { get; set; }
    }
}