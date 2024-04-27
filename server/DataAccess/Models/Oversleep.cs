namespace server.DataAccess.Models;

public class Oversleep
{
    public long Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateOnly Day { get; set; }
    public TimeSpan Amount { get; set; }
}
