using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain;
using server.Domain.UserScheduleManagement;

namespace server.API.Features.Attempt.AdaptationActions.FallingAsleepLevel.Create;

public class Endpoint(IRepository<FallingAsleepEase> fallingAsleepRepository)
    : Endpoint<Request, Results<Ok, ProblemDetails>>
{
    public override void Configure()
    {
        Post("/attempt/schedule/period/mark-falling-asleep");
        Summary(s =>
        {
            s.Summary = "Mark falling asleep level for period";
            s.Description = "Mark falling asleep level for period";
        });
    }

    public override async Task<Results<Ok, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        ThrowIfAnyErrors();
        await fallingAsleepRepository.AddAsync(new FallingAsleepEase
        {
            SleepPeriodId = req.SleepPeriodId,
            Day = req.Day,
            Level = req.Level
        }, true);
        return TypedResults.Ok();
    }
}
