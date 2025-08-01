using System.ComponentModel.DataAnnotations;
using Abcloudz.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Attributes
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var userService = (Abcloudz.WebAPI.Services.IUserService?)validationContext.GetService(typeof(Abcloudz.WebAPI.Services.IUserService));
            if (userService != null && value is string email)
            {
                var exists = userService.GetUsers(new UserQuery()).Any(u => u.Email == email);
                if (exists)
                    return new ValidationResult("Email must be unique.");
            }
            return ValidationResult.Success;
        }
    }
}
