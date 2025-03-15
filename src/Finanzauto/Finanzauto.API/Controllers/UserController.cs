using Finanzauto.Application.Dtos.User.Request;
using Finanzauto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finanzauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequestDto request)
        {
            var response = await _userApplication.RegisterUserAsync(request);
            return Ok(response);
        }
    }

}
