using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using WhatWatch.Application.Contracts;
using WhatWatch.Application.Settings;
using WhatWatch.Domain.Common;
using WhatWatch.Infrastructure.Persistence;
using WhatWatch.Infrastructure.Repositories;
using WhatWatch.Infrastructure.Services;

namespace WhatWatch.Infrastructure;

public static class InfrastructureServiceInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<IDomainEventService, DomainEventService>();

        services.AddTransient<IDateTime, DateTimeService>();

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

            var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
            return mongoClient.GetDatabase(serviceSettings.ServiceName);
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
