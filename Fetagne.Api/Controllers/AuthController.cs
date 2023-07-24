namespace Fetagne.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Fetagne.Contracts.Auth;
using Fetagne.Application.Auth;
using FluentResults;
using Fetagne.Application.Common.Errors;
using ErrorOr;
using Fetagne.Api.Controller;
using Fetagne.Application.Services.Auth;

[Route("auth")]
public class AuthController : ApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        ErrorOr<AuthResult> res = await _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.ConfirmPassword
        );

        return res.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        ErrorOr<AuthResult> res = await _authService.Login(request.Email, request.Password);

        return res.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthResponse MapAuthResult(AuthResult authResult)
    {
        return new AuthResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
    }
}
