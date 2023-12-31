using Fetagne.Api.Mapping;
using Fetagne.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Fetagne.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<ProblemDetailsFactory, FetagneProblemDetailsFactory>();
services.AddControllers();
        services.AddMapping();
        return services;
    }
}
