namespace Fetagne.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Fetagne.Contracts.Auth;
using Fetagne.Application.Auth;

[ApiController]
[Route("auth")]

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        AuthResult res = _authService.Register(request.FirstName, request.LastName, request.Email, request.Password, request.ConfirmPassword);
        return Ok(res);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        AuthResult res = _authService.Login(request.Email, request.Password);
        return Ok(res);
    }
}