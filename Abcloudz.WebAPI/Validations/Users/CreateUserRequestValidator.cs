using Abcloudz.WebAPI.Dto;
using FluentValidation;

namespace Abcloudz.WebAPI.Validations.Users
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(15)
                .WithMessage("Name cannot be longer than 15 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email address.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(4)
                .WithMessage("Password must be at least 4 characters long.");
        }
    }
}
