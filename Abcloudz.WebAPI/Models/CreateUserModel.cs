namespace Abcloudz.WebAPI.Models
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class UserModel : CreateUserModel
    {
        public int Id { get; set; }
    }
}
