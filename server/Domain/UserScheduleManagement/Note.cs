using System.ComponentModel.DataAnnotations;
using server.Domain.UserSchedule;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.Domain.UserScheduleManagement;

public class Note
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }

    [MaxLength(1000)] public string Content { get; set; }
    public virtual List<SleepPeriod> SleepPeriods { get; set; }
}
