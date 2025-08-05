using System.ComponentModel.DataAnnotations;

namespace Abcloudz.WebAPI.DataLayer.DTOs
{
	public class UserCreateDto
	{
		[Required(ErrorMessage = "Name is required")]
		[StringLength(100, ErrorMessage = "Name must be mo more then 100 symbols")]
		public required string Name { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Incorrect email")]
		public required string Email { get; set; }
	}
}
