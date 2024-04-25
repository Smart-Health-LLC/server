using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Localization;
using server.DataAccess.Interfaces;
using server.DataAccess.Models;

namespace server.API.Features.Public.GetFamilyScheduleList;

internal class Endpoint(
    IRepository<BaseScheduleFamily> repository,
    IStringLocalizer<FamilyScheduleResource> localization)
    : EndpointWithoutRequest<Results<Ok<List<BaseScheduleFamily>>, NotFound, ProblemDetails>>
{
    public override void Configure()
    {
        Get("/public/get-family-schedule-list");
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
        var families = await repository.GetAllAsync(tracked: false);
        if (families.Count == 0)
            return TypedResults.NotFound();

        foreach (var baseScheduleFamily in families)
        {
            var localizedString = localization.GetString(baseScheduleFamily.Name + ".Description");
            if (localizedString.ResourceNotFound)
                localizedString = null;
            baseScheduleFamily.Description = localizedString?.Value;
        }

        return TypedResults.Ok(families);
    }
}
