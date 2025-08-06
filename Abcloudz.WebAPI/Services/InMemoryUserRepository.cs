using System.Collections.Concurrent;
using Abcloudz.WebAPI.Entities;
using Abcloudz.WebAPI.Interfaces;
using Abcloudz.WebAPI.Models;

namespace Abcloudz.WebAPI.Services
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly IDictionary<int, DBUser> _dBUsers = new ConcurrentDictionary<int, DBUser>();

        public Task<DBUser> CreateAsync(DBUser user)
        {
            user.Id = _dBUsers.Count + 1;

            _dBUsers.Add(user.Id, user);

            return Task.FromResult(user);
        }

        public Task<IEnumerable<DBUser>> GetAllAsync(PaginationModel pagination)
        {
            return Task.FromResult(_dBUsers.Values
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize));
        }
    }
}
