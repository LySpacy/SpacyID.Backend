using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacyID.Application.Interfaces.Services;

namespace SpacyID.API.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : Controller
{

    private readonly IAuthService _authleService;

    public AuthController(IAuthService authService)
    {
        _authleService = authService;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login([FromQuery] string login)
    {

        var responce = await _authleService.SendAuthCode(login);

        return Ok(responce);
    }

    [HttpPost("code")]
    public async Task<IActionResult> VerifyCode([FromQuery] string login, string code)
    {
        var resultVerify = _authleService.VerifyAuthCode(login, code);

        if (!resultVerify)
        {
            return BadRequest("Неверный код.");
        }

        return Ok("Вы успешно вошли!");
    }
}
