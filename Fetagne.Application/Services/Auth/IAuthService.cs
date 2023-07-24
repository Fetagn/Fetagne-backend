namespace Fetagne.Application.Services.Auth;

using FluentResults;
using ErrorOr;

using Fetagne.Application.Auth;

public interface IAuthService
{
    Task<ErrorOr<AuthResult>> Register(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string ConfirmPassword
    );
    Task<ErrorOr<AuthResult>> Login(string Email, string Password);
}
