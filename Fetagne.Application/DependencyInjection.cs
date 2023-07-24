namespace Fetagne.Application;

using Fetagne.Application.Auth;
using Fetagne.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;


public static class DependencyInjection{

    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}