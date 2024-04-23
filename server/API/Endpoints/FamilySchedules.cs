using FastEndpoints;

namespace server.API.Endpoints;

public class FamilySchedules : EndpointWithoutRequest<FamilySchedulesResponse>
{
    public override void Configure()
    {
        Get("/family-schedules/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new FamilySchedulesResponse(), cancellation: ct);
    }
}

public class FamilySchedulesResponse
{
    public string prikol = "haha god why it's so hard. Please gime some brain power";
}
