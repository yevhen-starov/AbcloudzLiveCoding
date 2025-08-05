using Abcloudz.WebAPI.DataLayer.DTOs;
using Abcloudz.WebAPI.DataLayer.Entities;

namespace Abcloudz.WebAPI.BusinessLayer.Abstractions
{
	public interface IUserService
	{
		Task<IEnumerable<User>> GetAllAsync();
		Task<User> GetByIdAsync(Guid id);
		Task<User> CreateAsync(UserCreateDto customer);
		Task<bool> UpdateAsync(Guid id, User customer);
		Task<bool> DeleteAsync(Guid id);
	}
}
