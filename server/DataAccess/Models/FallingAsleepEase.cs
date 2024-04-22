using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class FallingAsleepEase
{
    public int Id { get; set; }

    // https://stackoverflow.com/questions/8542864/why-use-virtual-for-class-properties-in-entity-framework-model-definitions#8542879
    [ForeignKey("SleepPeriodId")] public virtual SleepPeriod SleepPeriod { get; set; }

    public DateTime DateTime { get; set; }

    [AllowedValues(1, 2, 3)] public int Level { get; set; }
}
