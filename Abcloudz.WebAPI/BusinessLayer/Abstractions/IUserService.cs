using Abcloudz.WebAPI.Common.Filters;
using Abcloudz.WebAPI.Common.PagedList;
using Abcloudz.WebAPI.DataLayer.DTOs;
using Abcloudz.WebAPI.DataLayer.Entities;

namespace Abcloudz.WebAPI.BusinessLayer.Abstractions
{
	public interface IUserService
	{
		Task<IPagedList<UserGetDto>> GetFiltered(Filter<UserGetDto> filter, CancellationToken cancellationToken);
		Task<List<UserGetDto>> GetAllAsync();
		Task<User> GetByIdAsync(Guid id);
		Task<User> CreateAsync(UserCreateDto customer);
		Task<bool> UpdateAsync(Guid id, User customer);
		Task<bool> DeleteAsync(Guid id);
	}
}
