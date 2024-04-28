using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain.UserSchedule;

namespace server.API.Features.Schedule.Attempt.GetActive;

public class Endpoint(
    IUserScheduleAttempt attemptRepository)
    : Endpoint<Request, Results<Ok<UserScheduleAttempt>, NoContent, ProblemDetails>>
{
    public override void Configure()
    {
        Get("/schedule/attempt/get-active/");
        Summary(s =>
        {
            s.Summary = "Gets user's schedule attempt";
            s.Description = "Gets user's schedule attempt";
        });
    }

    public override async Task<Results<Ok<UserScheduleAttempt>, NoContent, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        var attempt = await attemptRepository.GetActive(req.UserId);

        if (attempt is null)
            return TypedResults.NoContent();

        return TypedResults.Ok(attempt);
    }
}
