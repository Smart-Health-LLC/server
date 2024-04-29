using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using server.Domain;

namespace server.Persistence;

/**
 * Generic repository implementation
 */
public class Repository<T> : IRepository<T> where T : class
{
    /**
     * Used to get appropriate DbSet and save changes
     */
    private readonly DatabaseContext _applicationDbContext;

    protected readonly DbSet<T> DbSet;

    public Repository(DatabaseContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        DbSet = _applicationDbContext.Set<T>();
    }

    public async Task RemoveAsync(T entity, bool save = false)
    {
        DbSet.Remove(entity);

        if (save)
            await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, bool tracked = true)
    {
        IQueryable<T> query = DbSet;

        if (!tracked) query = query.AsNoTracking();

        return await query.SingleOrDefaultAsync(filter);
    }

    public async Task AddAsync(T entity, bool save = false)
    {
        await DbSet.AddAsync(entity);

        if (save)
            await SaveAsync();
    }

    public async Task AddCollectionAsync(IEnumerable<T> entities, bool save = false)
    {
        await DbSet.AddRangeAsync(entities);

        if (save)
            await SaveAsync();
    }


    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
    {
        IQueryable<T> query = DbSet;

        if (!tracked) query = query.AsNoTracking();

        if (filter != null) query = query.Where(filter!);
        return await query.ToListAsync();
    }
}
