using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using server.DataAccess.Interfaces;

namespace server.DataAccess.Repositories;

/**
 * Generic repository implementation
 */
public class Repository<T> : IRepository<T> where T : class
{
    private readonly DatabaseContext _applicationDbContext;
    private readonly DbSet<T> _dbSet;

    protected Repository(DatabaseContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _dbSet = _applicationDbContext.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _dbSet.Remove(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>>? filter, bool tracked = true)
    {
        IQueryable<T?> query = _dbSet;

        if (!tracked) query = query.AsNoTracking();

        if (filter != null) query = query.Where(filter!);
        return await query.FirstOrDefaultAsync(); // query will be executed here, deferred execution
    }

    public async Task<List<T?>> GetAllAsync(Expression<Func<T, bool>>? filter, bool tracked = true)
    {
        IQueryable<T?> query = _dbSet;

        if (!tracked) query = query.AsNoTracking();

        if (filter != null) query = query.Where(filter!);
        return await query.ToListAsync(); // query will be executed here, deferred execution
    }
}