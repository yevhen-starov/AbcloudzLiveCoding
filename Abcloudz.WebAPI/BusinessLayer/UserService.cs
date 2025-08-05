using Abcloudz.WebAPI.BusinessLayer.Abstractions;
using Abcloudz.WebAPI.Common.Filters;
using Abcloudz.WebAPI.Common.PagedList;
using Abcloudz.WebAPI.DataLayer;
using Abcloudz.WebAPI.DataLayer.DTOs;
using Abcloudz.WebAPI.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abcloudz.WebAPI.BusinessLayer
{
	public class UserService : IUserService
	{
		private readonly AppDbContext _dbContext;

		public UserService(AppDbContext _dbContext)
		{
			this._dbContext = _dbContext;
		}

		public async Task<IPagedList<UserGetDto>> GetFiltered(Filter<UserGetDto> filter, CancellationToken cancellationToken)
		{
			IQueryable<User> query = _dbContext.Users.AsQueryable();

			if (!string.IsNullOrWhiteSpace(filter.Filters?.Name))
			{
				query = query.Where(u => u.Name.Contains(filter.Filters.Name));
			}

			var totalCount = await query.CountAsync(cancellationToken);

			var items = await query
				.Skip((filter.Page - 1) * filter.PageSize)
				.Take(filter.PageSize)
				.Select(u => new UserGetDto
				{
					Id = u.Id,
					Name = u.Name,
					Email = u.Email
				})
				.ToListAsync(cancellationToken);

			return new PagedList<UserGetDto>(items, filter.Page, filter.PageSize, totalCount);
		}

		public async Task<User> GetByIdAsync(Guid id)
		{
			return await _dbContext.Users.FindAsync(id);
		}

		public async Task<List<UserGetDto>> GetAllAsync()
		{
			return await _dbContext.Users
				.Select(u => new UserGetDto
				{
					Id = u.Id,
					Name = u.Name,
					Email = u.Email
				})
				.ToListAsync();
		}

		public async Task<User> CreateAsync(UserCreateDto customerDto)
		{
			User customer = new User
			{
				Id = Guid.NewGuid(),
				Name = customerDto.Name,
				Email = customerDto.Email,
			};

			_dbContext.Users.Add(customer);
			await _dbContext.SaveChangesAsync();
			return customer;
		}

		public async Task<bool> UpdateAsync(Guid id, User customer)
		{
			if (id != customer.Id) return false;

			_dbContext.Entry(customer).State = EntityState.Modified;
			try
			{
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch (DbUpdateConcurrencyException)
			{
				return false;
			}
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var customer = await _dbContext.Users.FindAsync(id);
			if (customer == null) return false;

			_dbContext.Users.Remove(customer);
			await _dbContext.SaveChangesAsync();
			return true;
		}
	}
}
