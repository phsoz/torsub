using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WhatWatch.Application.Common.Interfaces;
using WhatWatch.Application.Settings;

namespace WhatWatch.Infrastructure.Persistence;

public class ApplicationDbContext : IApplicationDbContext
{
    private IMongoDatabase DbContext { get; set; }

    private MongoClient MongoClient { get; set; }

    //public IClientSessionHandle Session { get; set; }

    public ApplicationDbContext(IOptions<MongoDBSettings> configuration)
    {
        MongoClient = new MongoClient(configuration.Value.ConnectionString);
        DbContext = MongoClient.GetDatabase(configuration.Value.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return DbContext.GetCollection<T>(name);
    }

}
