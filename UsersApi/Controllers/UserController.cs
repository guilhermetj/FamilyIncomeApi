using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Services;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserDto createDto)
        {
            var result = _service.Create(createDto);
            if (result.IsFailed) return StatusCode(500);

            return Ok(result.Successes.FirstOrDefault());
        }
    }
}
