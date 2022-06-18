using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TorSub.Application.Contracts;
using TorSub.Infrastructure.Persistence;
using TorSub.Infrastructure.Repositories;
using TorSub.Infrastructure.Services;

namespace TorSub.Infrastructure;

public static class InfrastructureServiceRegister
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<IDomainEventService, DomainEventService>();

        services.AddTransient<IDateTime, DateTimeService>();
        
        services.AddTransient<IMovieRepository, MovieRepository>();
        services.AddTransient<ITestsRepository, TestsRepository>();

        return services;
    }
}
