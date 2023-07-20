namespace Fetagne.Application.Common.Interface.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid Id, string firstName, string lastName);
}