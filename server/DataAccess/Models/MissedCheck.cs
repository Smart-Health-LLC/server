namespace server.DataAccess.Models;

public class MissedCheck
{
    public int Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateOnly Day { get; set; }
}
