namespace server.DataAccess.Models;

public class MissedCheck
{
    public long Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateOnly Day { get; set; }
}
