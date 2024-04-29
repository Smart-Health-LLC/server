using System.ComponentModel.DataAnnotations;
using server.Domain.UserSchedule;

// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.Domain.UserScheduleManagement;

public class FallingAsleepEase
{
    public long Id { get; set; }

    // https://stackoverflow.com/questions/8542864/why-use-virtual-for-class-properties-in-entity-framework-model-definitions#8542879
    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateTime DateTime { get; set; }

    [AllowedValues(1, 2, 3)] public int Level { get; set; }
}
