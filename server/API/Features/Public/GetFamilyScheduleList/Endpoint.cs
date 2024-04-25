using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.DataAccess.Interfaces;
using server.DataAccess.Models;

namespace server.API.Features.Public.GetFamilyScheduleList;

public class Endpoint : EndpointWithoutRequest<Results<Ok<List<BaseScheduleFamily>>, NotFound, ProblemDetails>>
{
    public IRepository<BaseScheduleFamily> Repository { get; set; }

    public override void Configure()
    {
        Get("/family-schedules/get-family-schedule-list");
        Summary(s =>
        {
            s.Summary = "Gets all families schedules";
            s.Description = "Gets groups of sleep families schedules";
        });
        AllowAnonymous();
    }

    public override async Task<Results<Ok<List<BaseScheduleFamily>>, NotFound, ProblemDetails>> ExecuteAsync(
        CancellationToken ct)
    {
        var families = await Repository.GetAllAsync(tracked: false);
        if (families.Count == 0)
            return TypedResults.NotFound();

        return TypedResults.Ok(families);
    }
}
