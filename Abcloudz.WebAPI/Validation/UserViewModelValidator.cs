using Abcloudz.WebAPI.Models;
using FluentValidation;

namespace Abcloudz.WebAPI.Validation
{
    public class UserViewModelValidator : AbstractValidator<CreateUserModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("User model must not be null.");

            RuleFor(user => user.UserName)
                .NotNull()
                    .WithMessage("Username is required.")
                .MinimumLength(3)
                    .WithMessage("Username must be at least 3 characters long.");

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
