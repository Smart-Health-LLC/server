namespace server.DataAccess.Interfaces;

public interface IRefreshTokenRepository
{
    Task<bool> IsRequestTokenValid(long userId, string refreshToken);
    Task StoreToken(long userId, DateTime refreshExpiry, string refreshToken);
}
