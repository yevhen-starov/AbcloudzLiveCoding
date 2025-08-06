using Abcloudz.WebAPI.Entities;
using Abcloudz.WebAPI.Models;

namespace Abcloudz.WebAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<DBUser> CreateAsync(DBUser user);

        Task<IEnumerable<DBUser>> GetAllAsync(PaginationModel pagination);
    }
}
