namespace server.DataAccess.Models;

public class MissedCheck
{
    public int Id { get; set; }
    public SleepPeriod SleepPeriod { get; set; }
    public DateOnly Day { get; set; }
}
