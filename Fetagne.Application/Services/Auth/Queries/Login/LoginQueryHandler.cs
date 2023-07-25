using Fetagne.Application.Common.Interface.Auth;
using Fetagne.Application.Common.Interface.Persistence;
using Fetagne.Domain.Entities;
using Fetagne.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Fetagne.Application.Services.Auth.Common;

namespace Fetagne.Application.Services.Auth.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Task<ErrorOr<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetByEmail(query.Email);

        if (user == null || !user.VerifyPassword(query.Password))
        {
            return Task.FromResult<ErrorOr<AuthResult>>(Errors.Auth.WrongCreadital);
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return Task.FromResult<ErrorOr<AuthResult>>(new AuthResult(user, token));
    }
}
