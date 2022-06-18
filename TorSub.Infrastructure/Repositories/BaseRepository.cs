using MongoDB.Driver;
using System.Linq.Expressions;
using TorSub.Application.Contracts;
using TorSub.Domain.Common;

namespace TorSub.Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly IMongoDatabase Database;

    protected readonly IMongoCollection<T> DbSet;

    private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

    public BaseRepository(IMongoDatabase database)
    {
        Database = database;
        DbSet = Database.GetCollection<T>(typeof(T).Name);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await DbSet.Find(filterBuilder.Empty).ToListAsync();
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await DbSet.Find(filter).ToListAsync();
    }

    public async Task<T> GetAsync(string id)
    {
        FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, id);
        return await DbSet.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await DbSet.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        await DbSet.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, entity.Id);
        await DbSet.ReplaceOneAsync(filter, entity);
    }

    public async Task RemoveAsync(string id)
    {
        FilterDefinition<T> filter = filterBuilder.Eq(e => e.Id, id);
        await DbSet.DeleteOneAsync(filter);
    }

    private bool _disposed;
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }

    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose(true);
        // Suppress finalization.
        GC.SuppressFinalize(this);
    }
}
