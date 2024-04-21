namespace server.Models;

public class WakingUpEase
{
    public int Id { get; set; }
    public SleepPeriod SleepPeriod { get; set; }
    public DateTime DateTime { get; set; }
    public int Level { get; set; }
}
