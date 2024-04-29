namespace server.Services;

public class SleepPeriodAction
{
    public bool IsDeleted { get; set; }
    public bool IsCreated { get; set; }

    public bool IsChanged { get; set; }
    public long? Id { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
}
