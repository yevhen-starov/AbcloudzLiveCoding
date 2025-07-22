using Abcloudz.WebAPI.Models;

namespace Abcloudz.WebAPI.Repositories;
public class UserRepository : IUserRepository
{
    protected List<UserModel> _users = new List<UserModel>();
    public UserRepository()
    {

    }

    public async Task AddAsync(UserModel user)
    {
        user.Id = GetNextMaxId();
        _users.Add(user);

        return;
    }

    public List<UserModel> GetUsers()
    {
        return _users;
    }

    public int GetNextMaxId()
    {
        if (_users == null || !_users.Any()) {
            return 1;
        }

       return _users.Max(u => u.Id) + 1;
    }
}

public interface IUserRepository
{
    Task AddAsync(UserModel user);
    List<UserModel> GetUsers();
    int GetNextMaxId();
}
