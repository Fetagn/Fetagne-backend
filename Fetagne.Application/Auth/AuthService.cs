namespace Fetagne.Application.Auth;

public class AuthService : IAuthService
{
    public AuthResult Login(string Email, string Password)
    {
        return new AuthResult(Guid.NewGuid(), "Fetagne", "Alemu", "fetagne@gmail.com", "token");
    }

    public AuthResult Register(string FirstName, string LastName, string Email, string Password, string ConfirmPassword)
    {
        return new AuthResult(Guid.NewGuid(), "Fetagne", "Alemu", "fetagne@gmail.com", "token");
    }
}