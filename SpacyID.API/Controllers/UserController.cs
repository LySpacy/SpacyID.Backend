using Microsoft.AspNetCore.Mvc;

namespace SpacyID.API.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController : Controller
{

    [HttpGet("me")]
    public IActionResult GetUserData()
    {
        return View();
    }

    [HttpDelete("me")]
    public IActionResult DeleteUser()
    {
        return View();
    }

    //[HttpPut("me")]
    //public Task<IActionResult> UpdateUserData()
    //{

    //}

    //[HttpGet("data-options")]
    //public Task<IActionResult> GetUserDataOptions()
    //{

    //}
}
