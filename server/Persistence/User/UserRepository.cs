using Microsoft.EntityFrameworkCore;
using server.Domain.User;

namespace server.Persistence.User;

public class UserRepository(DatabaseContext applicationDbContext)
    : Repository<Domain.User.User>(applicationDbContext), IUserRepository
{
    public async Task<bool> IsUsernameTaken(string username)
    {
        var result = await DbSet.AnyAsync(u => u.Username == username);
        return result;
    }
}
