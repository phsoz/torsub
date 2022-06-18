using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using TorSub.Application.Settings;

namespace TorSub.Infrastructure;

public static class InfrastructureServiceConfiguration
{
    public static IServiceCollection AddMongo(this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        services.AddSingleton(x =>
        {
            var configuration = x.GetService<IConfiguration>();
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

}
