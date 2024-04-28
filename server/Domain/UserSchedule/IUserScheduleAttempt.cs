namespace server.Domain.UserSchedule;

public interface IUserScheduleAttempt : IRepository<UserScheduleAttempt>
{
    public Task<UserScheduleAttempt?> GetActive(long userId);

    public Task<bool> StartNew(UserScheduleAttempt userScheduleAttempt, long userId);
    public Task<bool> DropActive(long attemptId, long userId);
    public Task<bool> MarkAsAdopted(long attemptId, long userId);
}
