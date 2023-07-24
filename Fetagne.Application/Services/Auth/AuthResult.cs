namespace Fetagne.Application.Auth;
using Fetagne.Domain.Entities;

public record AuthResult (
    User User,
    string Token
);