namespace Abcloudz.WebAPI.Models
{
    public class UserQuery
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
