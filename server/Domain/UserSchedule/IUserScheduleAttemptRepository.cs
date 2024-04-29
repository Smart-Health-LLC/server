namespace server.Domain.UserSchedule;

public interface IUserScheduleAttemptRepository : IRepository<UserScheduleAttempt>
{
    public Task<UserScheduleAttempt?> GetActive(long userId, bool tracked = false);
    public Task<long?> GetActiveId(long userId);

    public Task<bool> Drop(long userId);
    public Task<bool> MarkAsAdopted(long userId);
}
