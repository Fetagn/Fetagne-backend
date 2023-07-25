namespace Fetagne.Application.Services.Auth.Queries.Login;
using Fetagne.Application.Services.Auth.Common;
using MediatR;
using ErrorOr;

public record LoginQuery(
    string Email,
    string Password
): IRequest<ErrorOr<AuthResult>>;