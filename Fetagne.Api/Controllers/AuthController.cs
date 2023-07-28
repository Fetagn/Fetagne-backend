using Microsoft.AspNetCore.Mvc;
using Fetagne.Contracts.Auth;
using Fetagne.Application.Services.Auth.Commands.Register;
using Fetagne.Application.Services.Auth.Queries.Login;
using ErrorOr;
using Fetagne.Api.Controller;
using Fetagne.Application.Services.Auth;
using MediatR;
using MapsterMapper;
using Fetagne.Application.Services.Auth.Common;

namespace Fetagne.Api.Controllers;
[Route("auth")]
public class AuthController : ApiController
{
    private readonly ISender _meditor;
    public readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _meditor = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthResult> res = await _meditor.Send(command);

        return res.Match(
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthResult> res = await _meditor.Send(query);

        return res.Match(
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
    }

}
