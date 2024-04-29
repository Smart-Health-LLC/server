using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain.UserSchedule;
using server.Services;

namespace server.API.Features.Attempt.Schedule.Get;

public class Endpoint(
    IUserScheduleService scheduleService)
    : Endpoint<Request, Results<Ok<List<SleepPeriod>>, NoContent, ProblemDetails>>
{
    public override void Configure()
    {
        Get("/schedule/get/");
        Summary(s =>
        {
            s.Summary = "Gets user's schedule";
            s.Description = "Gets user's schedule in separate sleep periods";
        });
    }

    public override async Task<Results<Ok<List<SleepPeriod>>, NoContent, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        var schedule = await scheduleService.GetSchedule(req.UserId);
        if (schedule is null)
            ThrowError("No schedule found, probably no active attempt exists");
        return TypedResults.Ok(schedule);
    }
}
