using System.ComponentModel.DataAnnotations;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace server.Domain.BaseSchedule;

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
