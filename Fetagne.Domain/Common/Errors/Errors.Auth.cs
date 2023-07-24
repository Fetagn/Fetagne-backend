namespace Fetagne.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class Auth
    {
        public static Error WrongCreadital =>
            Error.Validation(code: "Auth.InvalidCredentials", description: "Invalid Credentials");
    }
}
