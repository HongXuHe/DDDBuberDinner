using System.Reflection;
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Common.Behaviors;
using BuberDinner.Application.Common.Errors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OneOf;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
       // services.AddScoped<IPipelineBehavior<RegisterCommand,OneOf<AuthenticationResult,IError>>,ValidateRegisterCommandBehavior>();
         services.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
