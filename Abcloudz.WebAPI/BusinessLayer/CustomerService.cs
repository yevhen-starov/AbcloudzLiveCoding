using Abcloudz.WebAPI.DataLayer;
using Abcloudz.WebAPI.DataLayer.DTOs;
using Abcloudz.WebAPI.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abcloudz.WebAPI.BusinessLayer
{
	public class CustomerService : ICustomerService
	{
		private readonly AppDbContext _dbContext;

		public CustomerService(AppDbContext _dbContext)
		{
			this._dbContext = _dbContext;
		}

		public async Task<IEnumerable<Customer>> GetAllAsync()
		{
			return await _dbContext.Customers.ToListAsync();
		}

		public async Task<Customer> GetByIdAsync(Guid id)
		{
			return await _dbContext.Customers.FindAsync(id);
		}

		public async Task<Customer> CreateAsync(CustomerCreateDto customerDto)
		{
			Customer customer = new Customer
			{
				Id = Guid.NewGuid(),
				Name = customerDto.Name,
				Email = customerDto.Email,
			};

			_dbContext.Customers.Add(customer);
			await _dbContext.SaveChangesAsync();
			return customer;
		}

		public async Task<bool> UpdateAsync(Guid id, Customer customer)
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
			var customer = await _dbContext.Customers.FindAsync(id);
			if (customer == null) return false;

			_dbContext.Customers.Remove(customer);
			await _dbContext.SaveChangesAsync();
			return true;
		}
	}
}
