namespace Fetagne.Application;

using Fetagne.Application.Services.Auth.Commands.Register;
using Fetagne.Application.Services.Auth.Common;
using MediatR;
using ErrorOr;
using Microsoft.Extensions.DependencyInjection;
using Fetagne.Application.Common.Behaviors;
using System.Reflection;
using FluentValidation;

public static class DependencyInjection{

    public static IServiceCollection AddApplication(this IServiceCollection services){
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }

}