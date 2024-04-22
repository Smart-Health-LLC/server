namespace server.DataAccess.Models;

public class FallingAsleepEase
{
    public int Id { get; set; }

    // https://stackoverflow.com/questions/8542864/why-use-virtual-for-class-properties-in-entity-framework-model-definitions#8542879
    public virtual SleepPeriod SleepPeriod { get; set; }
    public DateTime DateTime { get; set; }
    public int Level { get; set; }
}
