namespace server.DataAccess.Models;

public class BaseSleepPeriod
{
    public long Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
