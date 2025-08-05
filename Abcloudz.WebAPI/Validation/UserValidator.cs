using Abcloudz.WebAPI.DataLayer.DTOs;
using FluentValidation;

namespace Abcloudz.WebAPI.Validation
{
	public class UserValidator : AbstractValidator<UserCreateDto>
	{
		public UserValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("Name is required")
				.Length(2, 50).WithMessage("Name must be from 2 to 50 chars");

			RuleFor(p => p.Email)
				.NotEmpty().WithMessage("Email is required")
				.EmailAddress().WithMessage("Invalid email ");
		}
	}
}
