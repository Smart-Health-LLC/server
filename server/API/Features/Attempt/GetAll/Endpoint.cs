using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain;
using server.Domain.UserSchedule;

namespace server.API.Features.Attempt.GetAll;

public class Endpoint(
    IRepository<UserScheduleAttempt> attemptRepository)
    : Endpoint<Request, Results<Ok<List<UserScheduleAttempt>>, NoContent, ProblemDetails>>
{
    public override void Configure()
    {
        Get("/schedule/attempt/get-all/");
        Summary(s =>
        {
            s.Summary = "Gets all user's schedule attempts";
            s.Description = "Gets all user's schedule attempts including active and dropped or adopted ones";
        });
    }

    public override async Task<Results<Ok<List<UserScheduleAttempt>>, NoContent, ProblemDetails>> ExecuteAsync(
        Request req,
        CancellationToken ct)
    {
        var attempts = await attemptRepository.GetAllAsync(attempt =>
                attempt.UserId == req.UserId, false
        );

        if (attempts.Count == 0)
            return TypedResults.NoContent();

        return TypedResults.Ok(attempts);
    }
}
