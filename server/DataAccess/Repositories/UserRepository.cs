using Microsoft.EntityFrameworkCore;
using server.DataAccess.Interfaces;
using server.DataAccess.Models;

namespace server.DataAccess.Repositories;

public class UserRepository(DatabaseContext applicationDbContext)
    : Repository<User>(applicationDbContext), IUserRepository
{
    public async Task<bool> IsUsernameTaken(string username)
    {
        var result = await _dbSet.AnyAsync(u => u.Username == username);
        return result;
    }
}
