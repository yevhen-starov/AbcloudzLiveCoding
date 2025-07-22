using System.ComponentModel.DataAnnotations;

namespace Abcloudz.WebAPI.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class CreateUserRequest
    {
        [MaxLength(15)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(4)]
        public string Password { get; set; }
    }
}
