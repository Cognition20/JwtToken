using Contracts.Interfaces.Services;
using Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var result = await authenticationService.Register(request);
        return Ok(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await authenticationService.Login(request);
        return Ok(result);
    }
}