using Microsoft.EntityFrameworkCore;
using server.Domain.User;

namespace server.Persistence.User;

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
        await DbSet.Where(t => t.UserId == userId).ExecuteDeleteAsync();

        var newToken = new JwtLastToken
        {
            UserId = userId,
            ExpiryDateTime = refreshExpiry,
            Token = refreshToken
        };
        await DbSet.AddAsync(newToken);
    }

    public async Task<bool> IsRequestTokenValid(long userId, string refreshToken)
    {
        var result = await DbSet.AsNoTracking().AnyAsync(t =>
            t.UserId == userId && t.Token == refreshToken && t.ExpiryDateTime >= DateTime.UtcNow);
        return result;
    }
}
