using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain;
using server.Domain.UserSchedule;

namespace server.API.Features.Schedule.Attempt.Start;

public class Endpoint(
    IRepository<UserScheduleAttempt> attemptRepository)
    : Endpoint<Request, Results<Ok, ProblemDetails>>
{
    public override void Configure()
    {
        Get("/schedule/attempt/start");
        Summary(s =>
        {
            s.Summary = "Sets user's schedule attempt";
            s.Description = "Sets user's schedule attempt";
        });
    }

    public override async Task<Results<Ok, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        await Task.CompletedTask;
        return TypedResults.Ok();
    }
}
