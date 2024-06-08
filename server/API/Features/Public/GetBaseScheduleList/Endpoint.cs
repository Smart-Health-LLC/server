using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain;
using server.Domain.BaseSchedule;

namespace server.API.Features.Public.GetBaseScheduleList;

public class Endpoint(IRepository<BaseSchedule> repository)
    : EndpointWithoutRequest<Results<Ok<List<BaseSchedule>>, ProblemDetails>>
{
    public override void Configure()
    {
        Get("/public/get-base-schedule-list/");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Gets base schedules";
            s.Description = "Gets base schedules";
        });
    }

    public override async Task<Results<Ok<List<BaseSchedule>>, ProblemDetails>> ExecuteAsync(
        CancellationToken ct)
    {
        // todo make optional param to get only family specific schedule now my brain can't handle that task
        var baseSchedules = await repository.GetAllAsync(tracked: false);
        return TypedResults.Ok(baseSchedules);
    }
}
