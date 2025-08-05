using Abcloudz.WebAPI.BusinessLayer.Abstractions;
using Abcloudz.WebAPI.Common.Filters;
using Abcloudz.WebAPI.DataLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(
			IUserService _customerService)
		{
			this._userService = _customerService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
		{
			if (dto == null)
			{
				throw new ArgumentNullException(nameof(dto));
			}

			var customer = await _userService.CreateAsync(dto);
			return Ok(new { Id = customer.Id });
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([FromQuery] Filter<UserGetDto> filter, CancellationToken cancellationToken)
		{
			var result = await _userService.GetAllAsync(filter, cancellationToken);
			return Ok(result);
		}

	}
}
