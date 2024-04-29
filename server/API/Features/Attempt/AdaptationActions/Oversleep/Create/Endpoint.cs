using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain;

namespace server.API.Features.Attempt.AdaptationActions.Oversleep.Create;

public class Endpoint(IRepository<Domain.UserScheduleManagement.Oversleep> oversleepRepository)
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
        await oversleepRepository.AddAsync(new Domain.UserScheduleManagement.Oversleep
        {
            Amount = req.Amount,
            SleepPeriodId = req.SleepPeriodId
        }, true);
        return TypedResults.Ok();
    }
}
