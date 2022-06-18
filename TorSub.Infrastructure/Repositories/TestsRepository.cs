using MongoDB.Driver;
using TorSub.Application.Contracts;
using TorSub.Domain.Entities;

namespace TorSub.Infrastructure.Repositories;

public class TestsRepository : BaseRepository<Tests>, ITestsRepository
{
    public TestsRepository(IMongoDatabase database) : base(database)
    {
    }
}
