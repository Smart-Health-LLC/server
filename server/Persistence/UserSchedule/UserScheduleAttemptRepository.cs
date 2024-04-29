using server.Domain.UserSchedule;

namespace server.Persistence.UserSchedule;

public class UserScheduleAttemptRepository(DatabaseContext applicationDbContext)
    : Repository<UserScheduleAttempt>(applicationDbContext), IUserScheduleAttemptRepository
{
    public async Task<bool> Drop(long userId)
    {
        var activeAttempt = await GetActive(userId, true);
        if (activeAttempt is null)
            return false;

        activeAttempt.IsDropped = true;
        await SaveAsync();
        return true;
    }


    public async Task<bool> MarkAsAdopted(long userId)
    {
        var activeAttempt = await GetActive(userId, true);
        if (activeAttempt is null)
            return false;

        activeAttempt.IsAdopted = true;
        await SaveAsync();
        return true;
    }

    public async Task<UserScheduleAttempt?> GetActive(long userId, bool tracked = false)
    {
        var activeAttempt = await GetAsync(attempt =>
            attempt.UserId == userId && !attempt.IsAdopted && !attempt.IsDropped, tracked);

        return activeAttempt;
    }
}
