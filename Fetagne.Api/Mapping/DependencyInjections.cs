using System.Reflection;
using Mapster;
using MapsterMapper;

namespace Fetagne.Api.Mapping;

public static class DependencyInjections
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}