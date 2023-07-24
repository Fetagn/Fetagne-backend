using Fetagne.Application.Common.Interface.Auth;
using Fetagne.Application.Common.Interface.Persistence;
using Fetagne.Domain.Entities;
using Fetagne.Domain.Common.Errors;
// using ErrorOr;
using FluentResults;
using Fetagne.Application.Common.Errors;
using ErrorOr;
using Fetagne.Application.Services.Auth;

namespace Fetagne.Application.Auth;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Task<ErrorOr<AuthResult>> Register(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string ConfirmPassword
    )
    {
        if (_userRepository.GetByEmail(Email) != null)
        {
            return Task.FromResult<ErrorOr<AuthResult>>(Errors.User.DuplicateEmail);
        }

        if (Password != ConfirmPassword)
        {
            return Task.FromResult<ErrorOr<AuthResult>>(Errors.User.PasswordNotMatch);
        }
        var user = new User(FirstName, LastName, Email, Password);
        _userRepository.Add(user);

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return Task.FromResult<ErrorOr<AuthResult>>(new AuthResult(user, token));
    }

    public Task<ErrorOr<AuthResult>> Login(string Email, string Password)
    {
        var user = _userRepository.GetByEmail(Email);

        if (user == null)
        {
            return Task.FromResult<ErrorOr<AuthResult>>(Errors.Auth.WrongCreadital);
        }
        var token = _jwtTokenGenerator.GenerateToken(user);
        return Task.FromResult<ErrorOr<AuthResult>>(new AuthResult(user, token));
    }
}
