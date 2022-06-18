using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using TorSub.Application.Contracts;
using TorSub.Application.Settings;
using TorSub.Domain.Common;
using TorSub.Domain.Entities;
using TorSub.Infrastructure.Persistence;
using TorSub.Infrastructure.Repositories;
using TorSub.Infrastructure.Services;

namespace TorSub.Infrastructure;

public static class InfrastructureServiceInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<IDomainEventService, DomainEventService>();

        services.AddTransient<IDateTime, DateTimeService>();

        services.AddMongo().AddMongoRepository<Movies>();
        services.AddTransient<IMovieRepository, MovieRepository>();
        services.AddTransient<ITestsRepository, TestsRepository>();

        //services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }

    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        services.AddSingleton(x =>
        {
            var configuration = x.GetService<IConfiguration>();
            var serviceSettings = configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
            var mongoDbSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

            
            
            var mongoConnectionUrl = new MongoUrl(mongoDbSettings.ConnectionString);
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
            mongoClientSettings.ClusterConfigurator = cb => {
                cb.Subscribe<CommandStartedEvent>(e => {
                    Console.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
                });
            };

            var mongoClient = new MongoClient(mongoClientSettings);

            return mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
        });

        return services;
    }

    public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services) where T : BaseEntity
    {
        services.AddSingleton<IRepository<T>>(x =>
        {
            var database = x.GetService<IMongoDatabase>();
            return new BaseRepository<T>(database);
        });
        return services;
    }
}
