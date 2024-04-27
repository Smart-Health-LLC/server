using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.DataAccess.Interfaces;
using server.DataAccess.Models;

namespace server.API.Features.Public.GetBaseScheduleList;

public class Endpoint(IRepository<BaseSchedule> repository)
    : EndpointWithoutRequest<Results<Ok<List<BaseSchedule>>, ProblemDetails>>
{
    public override void Configure()
    {
        Get("/public/get-base-schedule-list/");
        Summary(s =>
        {
            s.Summary = "Gets base schedules";
            s.Description = "Gets base schedules";
        });
        AllowAnonymous();
    }

    public override async Task<Results<Ok<List<BaseSchedule>>, ProblemDetails>> ExecuteAsync(
        CancellationToken ct)
    {
        // todo make optional param to get only family specific schedule now my brain can't handle that task
        var baseSchedules = await repository.GetAllAsync(tracked: false);
        return TypedResults.Ok(baseSchedules);
    }
}
