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
		private readonly IFileService _fileService;
		private readonly IValidator<UserCreateDto> _validator;

		public UserController(
			IUserService _customerService,
			IValidator<UserCreateDto> validator,
			IFileService fileService)
		{
			_userService = _customerService;
			_validator = validator;
			_fileService = fileService;
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

		[HttpPost("download")]
		public async Task<IActionResult> DownloadUsers([FromBody] DownloadUsersRequestDto request)
		{
			var fileBytes = await _fileService.SaveUsersToFileAsync(request.Filename, request.Users);

			return File(fileBytes, "application/json", request.Filename);
		}

	}
}
