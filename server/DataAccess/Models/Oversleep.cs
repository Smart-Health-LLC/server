using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class Oversleep
{
    public int Id { get; set; }

    [ForeignKey("SleepPeriodId")] public SleepPeriod SleepPeriod { get; set; }

    public DateOnly Day { get; set; }
    public TimeSpan Amount { get; set; }
}
