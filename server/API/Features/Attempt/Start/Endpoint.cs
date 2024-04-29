using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Services;

namespace server.API.Features.Attempt.Start;

public class Endpoint(
    IUserScheduleService scheduleService)
    : Endpoint<Request, Results<Ok, ProblemDetails>>
{
    public override void Configure()
    {
        Post("/schedule/attempt/start");
        Summary(s =>
        {
            s.Summary = "Sets user's schedule attempt";
            s.Description = "Sets user's schedule attempt";
        });
    }

    public override async Task<Results<Ok, ProblemDetails>> ExecuteAsync(Request req,
        CancellationToken ct)
    {
        var result = await scheduleService.StartNewAttempt(req.BaseScheduleId, req.UserId);
        // todo how to deal with such situations when first thing, that comes to mind, is utilizing custom Exceptions....
        if (!result)
            AddError(
                "Base schedule doesn't exist or you already have an active attempt. Drop it or mark as completed before starting new one");

        // copy sleep periods to 

        ThrowIfAnyErrors();

        return TypedResults.Ok();
    }
}
