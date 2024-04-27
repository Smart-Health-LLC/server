namespace server.DataAccess.Models;

public class BaseSleepPeriod
{
    public long Id { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public long BaseScheduleId { get; set; }
}
