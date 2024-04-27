using Microsoft.EntityFrameworkCore;
using server.DataAccess.Interfaces;
using server.DataAccess.Models;

namespace server.DataAccess.Repositories;

public class RefreshTokenRepository(DatabaseContext applicationDbContext)
    : Repository<JwtLastToken>(applicationDbContext), IRefreshTokenRepository
{
    /**
     * Call
     * <see cref="IsRequestTokenValid" />
     * first
     */
    public async Task StoreToken(long userId, DateTime refreshExpiry, string refreshToken)
    {
        await _dbSet.Where(t => t.UserId == userId).ExecuteDeleteAsync();

        var newToken = new JwtLastToken
        {
            UserId = userId,
            ExpiryDateTime = refreshExpiry,
            Token = refreshToken
        };
        await _dbSet.AddAsync(newToken);
    }

    public async Task<bool> IsRequestTokenValid(long userId, string refreshToken)
    {
        var result = await _dbSet.AsNoTracking().AnyAsync(t =>
            t.UserId == userId && t.Token == refreshToken && t.ExpiryDateTime >= DateTime.UtcNow);
        return result;
    }
}
