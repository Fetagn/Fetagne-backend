namespace Fetagne.Application;

using Fetagne.Application.Services.Auth;
using Fetagne.Application.Services.Auth.Commands.Register;
using Fetagne.Application.Services.Auth.Queries.Login;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


public static class DependencyInjection{

    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}