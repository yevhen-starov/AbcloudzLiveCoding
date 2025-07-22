using System.ComponentModel.DataAnnotations;

namespace Abcloudz.WebAPI.Dto
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
