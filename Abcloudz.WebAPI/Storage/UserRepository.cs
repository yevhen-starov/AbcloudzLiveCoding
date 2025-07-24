using Abcloudz.WebAPI.Domain;

namespace Abcloudz.WebAPI.Storage;

public class UserRepository
{
    private DbContext _context;
    
    public UserRepository(DbContext _context)
    {
        this._context = _context;
    }
    
    public List<User> GetUsers()
    {
        return _context.Users;
    }

    public void AddUser(User user)
    {
        user.Id = _context.Users.Any() ? _context.Users.Max(x => x.Id) + 1 : 1;
        _context.Users.Add(user);
    }
}