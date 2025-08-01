using System.ComponentModel.DataAnnotations;
using Abcloudz.WebAPI.Attributes;

namespace Abcloudz.WebAPI.Models
{
    public class CreateUserRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; } = string.Empty;
    }
}
