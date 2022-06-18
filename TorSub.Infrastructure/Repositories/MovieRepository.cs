using MongoDB.Driver;
using TorSub.Application.Contracts;
using TorSub.Domain.Entities;

namespace TorSub.Infrastructure.Repositories;

public class MovieRepository : BaseRepository<Movies>, IMovieRepository
{
    public MovieRepository(IMongoDatabase database) : base(database)
    {
    }
}
