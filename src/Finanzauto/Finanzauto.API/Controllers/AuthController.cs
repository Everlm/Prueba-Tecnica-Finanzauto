using Finanzauto.Application.Dtos.Auth.Request;
using Finanzauto.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finanzauto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApplication _authApplication;

        public AuthController(IAuthApplication authApplication)
        {
            _authApplication = authApplication;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
        {
            var response = await _authApplication.LoginAsync(requestDto);
            return Ok(response);
        }
    }
}
