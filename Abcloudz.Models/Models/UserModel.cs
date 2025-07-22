using Abcloudz.Models.Models;

namespace Abcloudz.WebAPI.Models
{
    public class UserModel: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
