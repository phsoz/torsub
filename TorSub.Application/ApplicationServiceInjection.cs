using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;
using TorSub.Application.Common.Behaviours;
using TorSub.Application.Settings;

namespace TorSub.Application;

public static class ApplicationServiceInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        return services;
    }
}
