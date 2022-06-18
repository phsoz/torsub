using MongoDB.Driver;

namespace TorSub.Application.Contracts;

public interface IApplicationDbContext
{
    IMongoDatabase DbContext { get; }
}

