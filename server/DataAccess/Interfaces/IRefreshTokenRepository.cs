namespace server.DataAccess.Interfaces;

public interface IRefreshTokenRepository
{
    Task<bool> IsRequestTokenValid(int userId, string refreshToken);
    Task StoreToken(int userId, DateTime refreshExpiry, string refreshToken);
}
