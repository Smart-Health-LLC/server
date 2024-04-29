using FastEndpoints;
using Microsoft.AspNetCore.Antiforgery;

namespace server.API.Features.Account.JWT.GetAntiforgery;

internal sealed class Endpoint : EndpointWithoutRequest
{
    // ReSharper disable once MemberCanBePrivate.Global
    public IAntiforgery AntiForgery { get; set; } = null!;

    public override void Configure()
    {
        Get("account/jwt/get-anti-forgery-token");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken c)
    {
        var tokenSet = AntiForgery.GetAndStoreTokens(HttpContext);
        await SendAsync(
            new
            {
                formFieldName = tokenSet.FormFieldName,
                token = tokenSet.RequestToken
            }, cancellation: c);
    }
}
