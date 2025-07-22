using Abcloudz.WebAPI.Models;

namespace Abcloudz.DAL.Interfaces;

public interface IUserRepository
{
    Task AddAsync(UserModel user);
    Task<List<UserModel>> GetUsersAsync(int pageNumber, int pageSize, string? search);
    Task<bool> IsExistAsync(string userName, string email);
}
