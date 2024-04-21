namespace server.Models;

public class Oversleep
{
    public int Id { get; set; }
    public SleepPeriod SleepPeriod { get; set; }
    public DateOnly Day { get; set; }
    public TimeSpan Amount { get; set; }
}
