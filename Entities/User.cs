using System;
using System.ComponentModel.DataAnnotations;


namespace OT113-Server.Entities {

	public class User : EntityBase
	{

		[Required]
		[MaxLenght(255)]
		public string firstName { get; set; }

		[Required]
		[MaxLength(255)]
		public string lastName { get; set; }

		[Required]
		[MaxLenght(320)]
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