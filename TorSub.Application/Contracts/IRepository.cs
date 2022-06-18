using System.Linq.Expressions;
using TorSub.Domain.Common;

namespace TorSub.Application.Contracts;

public interface IRepository<T> : IDisposable where T : BaseEntity
{
    Task CreateAsync(T entity);

    Task<IReadOnlyCollection<T>> GetAllAsync();

    Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);

    Task<T> GetAsync(string id);

    Task<T> GetAsync(Expression<Func<T, bool>> filter);

    Task RemoveAsync(string id);

    Task UpdateAsync(T entity);
}
