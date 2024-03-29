﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTOs
{
    public class UserUpdateDto
    {
		[Required]
		[MaxLength(255)]
		public string firstName { get; set; }

		[Required]
		[MaxLength(255)]
		public string lastName { get; set; }

		[Required]
		[MaxLength(320)]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MaxLength(100)]
		public string Password { get; set; }

		[MaxLength(255)]
		public string Photo { get; set; }

		[ForeignKey("Role")]
		public int roleId { get; set; }
	}
}
