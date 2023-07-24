namespace Fetagne.Infrastructure;

using Fetagne.Application.Common.Interface.Auth;
using Fetagne.Application.Common.Interface.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Fetagne.Infrastructure.Auth;
using Fetagne.Infrastructure.Services;
using Fetagne.Infrastructure.Persistence;
using Fetagne.Application.Common.Interface.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
