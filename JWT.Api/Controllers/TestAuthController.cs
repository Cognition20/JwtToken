using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers;

[ApiController]
[Authorize]
public class TestAuthController : ControllerBase
{
    [HttpGet("api/testauth")]
    public IActionResult TestAuth()
    {
        return Ok("You are now authenticated!");
    }
}