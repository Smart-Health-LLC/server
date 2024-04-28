using server.Domain.UserScheduleManagement;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.Domain.UserSchedule;

public class SleepPeriod
{
    public long Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsDeleted { get; set; }

    // todo interesting looooop
    public virtual UserScheduleAttempt Attempt { get; set; }
    public virtual List<Note> Notes { get; set; }
}
