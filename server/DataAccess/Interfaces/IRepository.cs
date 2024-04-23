using System.Linq.Expressions;

namespace server.DataAccess.Interfaces;

/**
 * Generic repository interface with typical CRUD operations
 */
public interface IRepository<T> where T : class
{
    Task<List<T?>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
    Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
    Task CreateAsync(T entity);
    Task RemoveAsync(T entity);
    Task SaveAsync();
}
