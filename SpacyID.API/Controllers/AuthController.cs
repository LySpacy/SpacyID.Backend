using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpacyID.Application.Interfaces.Services;

namespace SpacyID.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{

    private readonly IAuthService _authleService;

    public AuthController(IAuthService authService)
    {
        _authleService = authService;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login([FromQuery] string email)
    {

        await _authleService.SendAuthCodeToEmail(email);

        return Ok($"Код отправлен на почтовый адресс {email}.");
    }
}
