namespace Fetagne.Application.Auth
{
    public interface IAuthService
    {
        AuthResult Register(string FirstName, string LastName, string Email, string Password, string ConfirmPassword);
        AuthResult Login(string Email, string Password);
    }
}