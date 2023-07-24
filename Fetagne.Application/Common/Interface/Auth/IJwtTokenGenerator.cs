namespace Fetagne.Application.Common.Interface.Auth;
using Fetagne.Domain.Entities;
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}