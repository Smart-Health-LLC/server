using System.ComponentModel.DataAnnotations;

namespace server.DataAccess.Models;

public class WakingUpEase
{
    public long Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateTime DateTime { get; set; }

    [AllowedValues(1, 2, 3)] public int Level { get; set; }
}
