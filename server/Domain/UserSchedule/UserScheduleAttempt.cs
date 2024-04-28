using server.Domain.UserScheduleManagement;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.Domain.UserSchedule;

public class UserScheduleAttempt
{
    public long Id { get; set; }

    public virtual BaseSchedule.BaseSchedule BaseSchedule { get; set; }

    public bool IsDropped { get; set; }
    public bool IsAdopted { get; set; }
    public DateOnly DateStarted { get; set; }
    public DateOnly DateFinished { get; set; }

    public virtual List<Note> Notes { get; set; }

    public long UserId { get; set; }
}
