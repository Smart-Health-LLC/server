using server.Domain.UserSchedule;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.Domain.UserScheduleManagement;

public class Oversleep
{
    public long Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateOnly Day { get; set; }
    public TimeSpan Amount { get; set; }
}
