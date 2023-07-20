using Fetagne.Application.Common.Interface.Auth;

namespace Fetagne.Application.Auth;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthResult Login(string Email, string Password)
    {
        return new AuthResult(Guid.NewGuid(), "Fetagne", "Alemu", "fetagne@gmail.com", "token");
    }

    public AuthResult Register(string FirstName, string LastName, string Email, string Password, string ConfirmPassword)
    {
        var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), FirstName, LastName);
        return new AuthResult(Guid.NewGuid(), FirstName, LastName, Email, token);
    }
}