using Microsoft.EntityFrameworkCore;
using server.Domain.UserSchedule;

namespace server.Persistence.UserSchedule;

public class UserScheduleAttemptRepository(DatabaseContext applicationDbContext)
    : Repository<UserScheduleAttempt>(applicationDbContext), IUserScheduleAttempt
{
    public async Task<UserScheduleAttempt?> GetActive(long userId)
    {
        var activeAttempt = await _dbSet.AsNoTracking().Where(attempt =>
            attempt.UserId == userId && !attempt.IsAdopted && !attempt.IsArchived
        ).FirstOrDefaultAsync();
        return activeAttempt;
    }

    public async Task<bool> StartNew(UserScheduleAttempt userScheduleAttempt, long userId)
    {
        var activeAttempt = await GetActive(userId);
        if (activeAttempt is not null)
            return false;
        await CreateAsync(userScheduleAttempt);
        return true;
    }

    public async Task<bool> DropActive(long attemptId, long userId)
    {
        var activeAttempt = await GetActive(userId);
        if (activeAttempt is null)
            return false;
        throw new NotImplementedException();
    }

    public async Task<bool> ArchiveActive(long attemptId, long userId)
    {
        var activeAttempt = await GetActive(userId);
        if (activeAttempt is null)
            return false;
        throw new NotImplementedException();
    }

    public async Task<bool> MarkAsAdopted(long attemptId, long userId)
    {
        var activeAttempt = await GetActive(userId);
        if (activeAttempt is null)
            return false;
        throw new NotImplementedException();
    }
}
