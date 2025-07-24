using Abcloudz.WebAPI.Domain;

namespace Abcloudz.WebAPI.Storage;

public class DbContext
{
    public List<User> Users { get; set; } = [];
}