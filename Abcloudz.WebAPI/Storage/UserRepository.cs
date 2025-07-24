using Abcloudz.WebAPI.Domain;

namespace Abcloudz.WebAPI.Storage;

public class UserRepository(IDataStorage<User> usersStorage)
{
    public Task<List<User>> GetUsers() => usersStorage.LoadAsync();

    public async Task AddUser(User user)
    {
        var users = (await usersStorage.LoadAsync()).ToList();
        user.Id = users.Count == 0 ? 1 : users.Max(x => x.Id) + 1;
        await usersStorage.AddAsync(user);
    }
}