using Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities {

	public class User : EntityBase
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
		[MaxLength(20)]
		public string Password { get; set; }

		[MaxLength(255)]
		public string Photo { get; set; }

		[ForeignKey("Role")]
		public int roleId { get; set; }

	}

}