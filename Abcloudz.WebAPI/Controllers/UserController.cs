using Abcloudz.WebAPI.Interfaces;
using Abcloudz.WebAPI.Mappers;
using Abcloudz.WebAPI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> Create(CreateUserModel createUserModel, IUserService userService, IValidator<CreateUserModel> validator)
        {
            var validationResult = validator.Validate(createUserModel);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage)), nameof(createUserModel));
            }

            var create = await userService.CreateAsync(createUserModel.MapToDto());

            return Ok(create);
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetList([FromQuery]PaginationModel pagination, IUserService userService)
        {
            var list = await userService.GetAllAsync(pagination);

            return Ok(list);
        }
    }
}
