using server.Domain.UserScheduleManagement;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.Domain.UserSchedule;

public class SleepPeriod
{
    public long Id { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public bool IsDeleted { get; set; }

    public virtual List<Note> Notes { get; set; }

    public long UserScheduleAttemptId { get; set; }
}
