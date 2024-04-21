namespace server.Models;

public class SkippedPeriod
{
    public int Id { get; set; }
    public SleepPeriod SleepPeriod { get; set; }
    public DateOnly Day { get; set; }
}
