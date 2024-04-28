using System.Linq.Expressions;

namespace server.Domain;

/**
 * Generic repository interface with typical CRUD operations
 * NOTE generally it's a pattern implementation mistake, but for now it's super convenient so I don't give a shit
 */
public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
    Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
    Task CreateAsync(T entity);
    Task RemoveAsync(T entity);
    Task SaveAsync();
}
