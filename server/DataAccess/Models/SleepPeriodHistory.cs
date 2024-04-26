namespace server.DataAccess.Models;

public class SleepPeriodHistory
{
    public int Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public TimeSpan TimeStart { get; set; }
    public TimeSpan TimeEnd { get; set; }

    public DateTime CreatedAd { get; set; }
}
