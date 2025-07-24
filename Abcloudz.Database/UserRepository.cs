using Abcloudz.Application;
using Abcloudz.Application.Domain;

namespace Abcloudz.Database;

public class UserRepository(IDataStorage<User> usersStorage) : IRepository<User>
{
    public Task<List<User>> GetUsers() => usersStorage.LoadAsync();

    public async Task AddUser(User user)
    {
        var users = (await usersStorage.LoadAsync()).ToList();
        user.Id = users.Count == 0 ? 1 : users.Max(x => x.Id) + 1;
        await usersStorage.AddAsync(user);
    }
}