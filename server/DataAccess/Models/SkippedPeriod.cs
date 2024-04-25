namespace server.DataAccess.Models;

public class SkippedPeriod
{
    public int Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateOnly Day { get; set; }
}
