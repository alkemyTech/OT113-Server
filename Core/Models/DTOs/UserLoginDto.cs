using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{
    public class UserLoginDto
    {
		[Required]
		[MaxLength(320)]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MaxLength(20)]
		public string Password { get; set; }
	}
}
