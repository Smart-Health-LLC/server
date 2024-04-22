namespace server.DataAccess.Models;

public class BaseSchedule
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ShortName { get; set; }
    public string? Description { get; set; }
    public TimeSpan TotalSleepTime { get; set; }
    public virtual List<BaseSleepPeriod> SleepPeriods { get; set; }
}