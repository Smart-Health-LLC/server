namespace server.Domain.UserSchedule;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class SleepPeriodHistory
{
    public long Id { get; set; }

    public virtual SleepPeriod SleepPeriod { get; set; }

    public TimeSpan TimeStart { get; set; }
    public TimeSpan TimeEnd { get; set; }

    public DateTime CreatedAd { get; set; }
}
