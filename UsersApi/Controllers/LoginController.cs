using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Requests;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _service;
        public LoginController(LoginService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult LoginUser(LoginRequest request)
        {
            var result = _service.LoginUser(request);
            if (result.IsFailed) return Unauthorized();
            return Ok();
        }
    }
}
