using System.ComponentModel.DataAnnotations;

namespace server.DataAccess.Models;

public class BaseSchedule
{
    public long Id { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    [MaxLength(10)] public string? ShortName { get; set; }

    [MaxLength(1000)] public string? Description { get; set; }

    public TimeSpan TotalSleepTime { get; set; }

    public virtual List<BaseSleepPeriod> SleepPeriods { get; set; }

    // // have to use to seed data correctly
    public long BaseScheduleFamilyId { get; set; }
}
