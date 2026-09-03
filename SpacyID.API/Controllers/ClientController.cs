using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace SpacyID.API.Controllers;

[ApiController]
[Route("api/v1/client")]
public class ClientController : Controller
{

    [HttpGet("ping")]
    public IActionResult Index()
    {
        return Ok("pong");
    }
}
