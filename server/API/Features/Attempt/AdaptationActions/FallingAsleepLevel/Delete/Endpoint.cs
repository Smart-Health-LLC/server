using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain;
using server.Domain.UserScheduleManagement;

namespace server.API.Features.Attempt.AdaptationActions.FallingAsleepLevel.Delete;

public class Endpoint(IRepository<FallingAsleepEase> fallingAsleepRepository)
    : Endpoint<Request, Results<Ok, NotFound>>
{
    public override void Configure()
    {
        Post("/attempt/schedule/period/edit-falling-asleep");
        Summary(s =>
        {
            s.Summary = "Edit falling asleep level mark";
            s.Description = "Edit falling asleep level mark";
        });
    }

    public override async Task<Results<Ok, NotFound>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        ThrowIfAnyErrors();
        var mark = await fallingAsleepRepository.GetAsync(e => e.Id == req.MarkId, false);

        if (mark is null)
            return TypedResults.NotFound();

        await fallingAsleepRepository.RemoveAsync(mark, true);
        return TypedResults.Ok();
    }
}
