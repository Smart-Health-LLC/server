using FastEndpoints;
using Microsoft.AspNetCore.Antiforgery;

namespace server.API.Features.Account.JWT.GetAntiforgery;

internal sealed class Endpoint : EndpointWithoutRequest
{
    public IAntiforgery Antiforgery { get; set; }

    public override void Configure()
    {
        Get("account/jwt/get-anti-forgery-token");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        var tokenSet = Antiforgery.GetAndStoreTokens(HttpContext);
        await SendAsync(
            new
            {
                formFieldName = tokenSet.FormFieldName,
                token = tokenSet.RequestToken
            }, cancellation: c);
    }
}
