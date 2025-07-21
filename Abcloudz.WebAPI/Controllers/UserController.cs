using Microsoft.AspNetCore.Mvc;

namespace Abcloudz.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok();
        }
    }
}
