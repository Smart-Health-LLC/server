namespace server.API.Features.Attempt.AdaptationActions.FallingAsleepLevel.Create;

public class Request
{
    public DateOnly Day { get; set; }
    public long SleepPeriodId { get; set; }
    public int Level { get; set; }
}
