using Abcloudz.WebAPI.Application.Commands.UserDocuments.DownloadUserDocument;
using Abcloudz.WebAPI.Application.Commands.UserDocuments.GetUserDocument;
using Abcloudz.WebAPI.Application.Commands.UserDocuments.UploadUserDocument;
using Abcloudz.WebAPI.Application.Commands.Users.CreateUser;
using Abcloudz.WebAPI.Application.Queries.Users;
using Abcloudz.WebAPI.Dto;
using Abcloudz.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ServiceFilter(typeof(ExceptionFilter))] 
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> CreateUser(CreateUserRequest user)
        {
            var command = new CreateUserCommand(user);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Users([FromQuery] UserFilter filter)
        {
            var query = new GetUsersQuery(filter);
            var users = await _mediator.Send(query);

            return Ok(users);
        }

        #region endpoints for separate controller but I already want to sleep :), sorry Yevhenii
        [HttpPost("{userId}/upload-document")]
        public async Task<IActionResult> UploadDocument(int userId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var stream = file.OpenReadStream();

            var savedFilePath = await _mediator.Send(new UploadUserDocumentCommand(userId, file.FileName, stream));

            return Ok(new { Path = savedFilePath });
        }

        [HttpGet("{userId}/documents")]
        public async Task<IActionResult> GetUserDocuments(int userId)
        {
            var result = await _mediator.Send(new GetUserDocumentsQuery(userId));
            return Ok(result);
        }

        [HttpGet("{userId}/documents/{documentId}/download")]
        public async Task<IActionResult> DownloadDocument(int userId, Guid documentId)
        {
            var result = await _mediator.Send(new DownloadUserDocumentQuery(documentId));

            return File(result.Content, "application/octet-stream", result.FileName);
        }
        #endregion
    }
}
