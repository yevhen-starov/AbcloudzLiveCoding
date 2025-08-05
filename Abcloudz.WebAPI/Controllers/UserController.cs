using Abcloudz.WebAPI.BusinessLayer.Abstractions;
using Abcloudz.WebAPI.Common.Filters;
using Abcloudz.WebAPI.DataLayer.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IValidator<UserCreateDto> _validator;

		public UserController(
			IUserService _customerService,
			IValidator<UserCreateDto> validator)
		{
			_userService = _customerService;
			_validator = validator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] UserCreateDto dto)
		{
			var validationResult = await _validator.ValidateAsync(dto);

			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult.Errors);
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
