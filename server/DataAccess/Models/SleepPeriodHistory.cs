using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class SleepPeriodHistory
{
    public int Id { get; set; }

    [ForeignKey("SleepPeriodId")] public SleepPeriod SleepPeriod { get; set; }

    public TimeSpan TimeStart { get; set; }
    public TimeSpan TimeEnd { get; set; }
}
