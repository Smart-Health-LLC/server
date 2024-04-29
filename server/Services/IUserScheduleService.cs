using server.Domain.UserSchedule;

namespace server.Services;

/**
 * In general this shit combines sleep related stuff kill me aaah
 */
public interface IUserScheduleService
{
    public Task<bool> StartNewAttempt(long baseScheduleId, long userId);

    public Task<List<SleepPeriod>?> GetSchedule(long userId, bool tracked = false);

    public Task<List<string>> UpdateSchedule(List<SleepPeriodAction> sleepPeriodChanges, long userId);
}
