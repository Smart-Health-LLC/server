// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Domain.BaseSchedule;

public class BaseScheduleFamily
{
    public long Id { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    // localized value is stored in resource files on the server separately
    [NotMapped] public string? Description { get; set; }

    public virtual List<BaseSchedule> BaseSchedules { get; set; }
}
