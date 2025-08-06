using Abcloudz.WebAPI.DTOs;
using FluentValidation;

namespace Abcloudz.WebAPI.Validation
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("User model must not be null.");

            RuleFor(user => user.Name)
                .NotNull()
                    .WithMessage("Name is required.")
                .MinimumLength(3)
                    .WithMessage("Name must be at least 3 characters long.");

            RuleFor(user => user.Email)
                .NotNull()
                    .WithMessage("Email is required.")
                .MinimumLength(3)
                    .WithMessage("Email must be at least 3 characters long.")
                .EmailAddress()
                    .WithMessage("Email must be a valid email address.");
        }
    }
}
