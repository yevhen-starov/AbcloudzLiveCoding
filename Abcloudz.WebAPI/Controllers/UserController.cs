using Abcloudz.WebAPI.BusinessLayer.Abstractions;
using Abcloudz.WebAPI.DataLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public UserController(
			ICustomerService _customerService)
		{
			this._customerService = _customerService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CustomerCreateDto dto)
		{
			if (dto == null)
			{
				throw new ArgumentNullException(nameof(dto));
			}

			var customer = await _customerService.CreateAsync(dto);
			return Ok(new { Id = customer.Id });
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var customers = await _customerService.GetAllAsync();
			return Ok(customers);
		}

	}
}
