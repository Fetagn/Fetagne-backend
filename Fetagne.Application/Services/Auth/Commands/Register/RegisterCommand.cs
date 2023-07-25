namespace Fetagne.Application.Services.Auth.Commands.Register;
using MediatR;
using Fetagne.Application.Services.Auth.Common;
using ErrorOr;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string ConfirmPassword

): IRequest<ErrorOr<AuthResult>>;