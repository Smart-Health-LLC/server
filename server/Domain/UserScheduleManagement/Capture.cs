using System.ComponentModel.DataAnnotations;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.Domain.UserScheduleManagement;

public class Capture
{
    [Key] public long Id { get; set; }

    public virtual User.User User { get; set; }

    public DateTime? StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string TypeName { get; set; }
    public double Value { get; set; }
}
