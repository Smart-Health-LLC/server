namespace server.Models;

public class SleepPeriodHistory
{
    public int Id { get; set; }
    public SleepPeriod SleepPeriod { get; set; }
    public TimeSpan TimeStart { get; set; }
    public TimeSpan TimeEnd { get; set; }
}
