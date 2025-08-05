using Abcloudz.WebAPI.BusinessLayer.Abstractions;
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

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _dbContext.Users.ToListAsync();
		}

		public async Task<User> GetByIdAsync(Guid id)
		{
			return await _dbContext.Users.FindAsync(id);
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
