namespace Fetagne.Application.Services.Auth.Common;

using Fetagne.Domain.Entities;

public record AuthResult(User User, string Token);
