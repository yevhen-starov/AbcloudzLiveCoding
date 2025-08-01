using Abcloudz.WebAPI.Models;
using System.Collections.Concurrent;
using Microsoft.Extensions.Configuration;

namespace Abcloudz.WebAPI.Services
{
    public interface IUserService
    {
        User CreateUser(string name, string email);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(UserQuery query);
    }

    public class UserService : IUserService
    {
        private readonly ConcurrentDictionary<int, User> _users = new();
        private int _idCounter = 1;
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User CreateUser(string name, string email)
        {
            var user = new User
            {
                Id = _idCounter++,
                Name = name,
                Email = email
            };
            _users[user.Id] = user;
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _users.Values;
        }

        public IEnumerable<User> GetUsers(UserQuery query)
        {
            var filtered = _users.Values.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Name))
                filtered = filtered.Where(u => u.Name.Contains(query.Name, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(query.Email))
                filtered = filtered.Where(u => u.Email.Contains(query.Email, StringComparison.OrdinalIgnoreCase));
            return filtered
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToList();
        }
    }
}
