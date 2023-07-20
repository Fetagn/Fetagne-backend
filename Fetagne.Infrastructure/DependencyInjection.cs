namespace Fetagne.Infrastructure;

using Fetagne.Application.Common.Interface.Auth;
using Fetagne.Application.Common.Interface.Services;
using Microsoft.Extensions.DependencyInjection;
using Fetagne.Infrastructure.Auth;
using Fetagne.Infrastructure.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}