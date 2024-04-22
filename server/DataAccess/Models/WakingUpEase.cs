using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class WakingUpEase
{
    public int Id { get; set; }

    [ForeignKey("SleepPeriodId")] public SleepPeriod SleepPeriod { get; set; }

    public DateTime DateTime { get; set; }

    [AllowedValues(1, 2, 3)] public int Level { get; set; }
}
