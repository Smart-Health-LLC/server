using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain;
using server.Domain.UserScheduleManagement;

namespace server.API.Features.Attempt.AdaptationActions.FallingAsleepLevel.Edit;

public class Endpoint(IRepository<FallingAsleepEase> fallingAsleepRepository)
    : Endpoint<Request, Results<Ok, NotFound, ProblemDetails>>
{
    public override void Configure()
    {
        Post("/attempt/mark-falling-asleep");
        Summary(s =>
        {
            s.Summary = "Mark falling asleep level for period";
            s.Description = "Mark falling asleep level for period";
        });
    }

    public override async Task<Results<Ok, NotFound, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        var mark = await fallingAsleepRepository.GetAsync(mark => mark.Id == req.FallingAsleepEaseLevelId);
        if (mark is null)
            return TypedResults.NotFound();

        mark.Level = req.NewLevel;
        await fallingAsleepRepository.SaveAsync();
        return TypedResults.Ok();
    }
}
