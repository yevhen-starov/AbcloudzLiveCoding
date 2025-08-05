using Abcloudz.WebAPI.DataLayer.DTOs;
using Abcloudz.WebAPI.DataLayer.Entities;

namespace Abcloudz.WebAPI.BusinessLayer.Abstractions
{
	public interface ICustomerService
	{
		Task<IEnumerable<Customer>> GetAllAsync();
		Task<Customer> GetByIdAsync(Guid id);
		Task<Customer> CreateAsync(CustomerCreateDto customer);
		Task<bool> UpdateAsync(Guid id, Customer customer);
		Task<bool> DeleteAsync(Guid id);
	}
}
