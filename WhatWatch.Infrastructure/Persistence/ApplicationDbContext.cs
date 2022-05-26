using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WhatWatch.Application.Contracts;
using WhatWatch.Application.Settings;

namespace WhatWatch.Infrastructure.Persistence;

public class ApplicationDbContext : IApplicationDbContext
{
    public IMongoDatabase DbContext { get; set; }

    public ApplicationDbContext(IOptions<AppSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        DbContext = mongoClient.GetDatabase(options.Value.DatabaseName);
    }
}
