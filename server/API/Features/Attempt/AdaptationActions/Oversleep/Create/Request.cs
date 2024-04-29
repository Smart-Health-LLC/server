namespace server.API.Features.Attempt.AdaptationActions.Oversleep.Create;

public class Request
{
    public long SleepPeriodId { get; set; }
    public TimeSpan Amount { get; set; }
}
