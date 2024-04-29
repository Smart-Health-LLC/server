using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Services;

namespace server.API.Features.Schedule.Set;

public class Endpoint(IUserScheduleService scheduleService)
    : Endpoint<Request, Results<Ok, ProblemDetails>>
{
    public override void Configure()
    {
        Post("/schedule/set/");
    }

    public override async Task<Results<Ok, ProblemDetails>> ExecuteAsync(Request req, CancellationToken c)
    {
        var errors = await scheduleService.UpdateSchedule(req.SleepActionsToPerform, req.UserId);
        if (errors.Count == 0)
            return TypedResults.Ok();

        foreach (var error in errors) AddError(error);
        return new ProblemDetails();
    }
}
