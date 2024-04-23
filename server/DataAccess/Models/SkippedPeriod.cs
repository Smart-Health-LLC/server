using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class SkippedPeriod
{
    public int Id { get; set; }

    [ForeignKey("SleepPeriodId")] public virtual SleepPeriod SleepPeriod { get; set; }

    public DateOnly Day { get; set; }
}
