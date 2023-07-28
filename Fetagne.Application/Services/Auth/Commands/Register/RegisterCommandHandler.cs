using Fetagne.Application.Common.Interface.Auth;
using Fetagne.Application.Common.Interface.Persistence;
using Fetagne.Domain.Entities;
using Fetagne.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Fetagne.Application.Services.Auth.Common;

namespace Fetagne.Application.Services.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Task<ErrorOr<AuthResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetByEmail(command.Email) != null)
        {
            return Task.FromResult<ErrorOr<AuthResult>>(Errors.User.DuplicateEmail);
        }
        var user = new User(command.FirstName, command.LastName, command.Email, command.Password);
        _userRepository.Add(user);

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return Task.FromResult<ErrorOr<AuthResult>>(new AuthResult(user, token));
    }

}
