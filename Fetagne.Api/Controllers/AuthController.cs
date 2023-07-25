using Microsoft.AspNetCore.Mvc;
using Fetagne.Contracts.Auth;
using Fetagne.Application.Services.Auth.Commands.Register;
using Fetagne.Application.Services.Auth.Queries.Login;
using ErrorOr;
using Fetagne.Api.Controller;
using Fetagne.Application.Services.Auth;
using MediatR;
using Fetagne.Application.Services.Auth.Common;

namespace Fetagne.Api.Controllers;
[Route("auth")]
public class AuthController : ApiController
{
    
    private readonly ISender _meditor = null!;

    public AuthController(ISender mediator)
    {
        _meditor = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password, request.ConfirmPassword);
        ErrorOr<AuthResult> res = await _meditor.Send(command);

        return res.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        ErrorOr<AuthResult> res = await _meditor.Send(query);

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
