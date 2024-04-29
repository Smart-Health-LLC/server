using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain.UserSchedule;

namespace server.API.Features.Schedule.Attempt.Complete;

public class Endpoint(
    IUserScheduleAttemptRepository attemptRepository)
    : Endpoint<Request, Results<Ok, ProblemDetails>>
{
    public override void Configure()
    {
        Post("/schedule/attempt/start");
        Summary(s =>
        {
            s.Summary = "Drops user's schedule attempt";
            s.Description = "Drops user's schedule attempt";
        });
    }

    public override async Task<Results<Ok, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        var result = await attemptRepository.MarkAsAdopted(req.UserId);
        if (!result)
            AddError(
                "You don't have active attempt right now");

        ThrowIfAnyErrors();

        return TypedResults.Ok();
    }
}
