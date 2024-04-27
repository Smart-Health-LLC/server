using System.ComponentModel.DataAnnotations;

namespace server.DataAccess.Models;

public class FallingAsleepEase
{
    public long Id { get; set; }

    // https://stackoverflow.com/questions/8542864/why-use-virtual-for-class-properties-in-entity-framework-model-definitions#8542879
    public virtual SleepPeriod SleepPeriod { get; set; }

    public DateTime DateTime { get; set; }

    [AllowedValues(1, 2, 3)] public int Level { get; set; }
}
