using System.ComponentModel.DataAnnotations;

namespace Core.Models.DTOs
{
    public class OrganizationDtoPostRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Image { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        public string WelcomeText { get; set; }

        [Required]
        [MaxLength(2000)]
        public string AboutUsText { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Facebook { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Linkedin { get; set; }

        [Required]
        [MaxLength(65535)]
        public string Instagram { get; set; }
    }
}