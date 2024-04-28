using Microsoft.EntityFrameworkCore;
using server.Domain.User;
using server.Domain.UserSchedule;

namespace server.Persistence.User;

public class UserRepository(DatabaseContext applicationDbContext)
    : Repository<Domain.User.User>(applicationDbContext), IUserRepository
{
    public async Task<bool> IsUsernameTaken(string username)
    {
        var result = await _dbSet.AnyAsync(u => u.Username == username);
        return result;
    }

    public async Task<UserScheduleAttempt?> GetAttempt(long userId)
    {
        var attempt = await _dbSet.AsNoTracking().Where(u => u.Id == userId)
            .Include(u => u.Attempts.Where(a => !a.IsAdopted && !a.IsArchived)).FirstOrDefaultAsync();
    }
}
