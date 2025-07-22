using Abcloudz.Models.Interfaces;

namespace Abcloudz.WebAPI.Models
{
    public class UserModel : IBaseEntity<int>, ICreatable, IUpdatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
