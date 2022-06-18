using MongoDB.Driver;

namespace TorSub.Application.Contracts
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
