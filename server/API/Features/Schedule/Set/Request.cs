using server.Services;

namespace server.API.Features.Schedule.Set;

public class Request
{
    public long UserId { get; set; }
    public List<SleepPeriodAction> SleepActionsToPerform { get; set; }
}
