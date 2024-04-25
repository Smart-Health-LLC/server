namespace server.DataAccess.Models;

public class Oversleep
{
    public int Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateOnly Day { get; set; }
    public TimeSpan Amount { get; set; }
}
