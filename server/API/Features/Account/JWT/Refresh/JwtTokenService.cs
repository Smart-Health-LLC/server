using FastEndpoints;
using FastEndpoints.Security;
using server.Domain.User;

namespace server.API.Features.Account.JWT.Refresh;

public class JwtTokenService : RefreshTokenService<Request, Response>
{
    public JwtTokenService(IConfiguration config)
    {
        Setup(x =>
        {
            x.TokenSigningKey = config["JWTSigningKey"];
            x.AccessTokenValidity = TimeSpan.FromMinutes(1);
            x.RefreshTokenValidity = TimeSpan.FromHours(1);
            x.Endpoint("/account/refresh-token/",
                ep => { ep.Summary(s => s.Description = "refresh jwt token endpoint"); });
        });
    }

    // ReSharper disable once MemberCanBePrivate.Global
    public IRefreshTokenRepository RefreshTokenRepository { get; set; } = null!;

    public override Task PersistTokenAsync(Response rsp)
    {
        return RefreshTokenRepository.StoreToken(rsp.LongUserId, rsp.RefreshExpiry, rsp.RefreshToken);
    }

    public override async Task RefreshRequestValidationAsync(Request req)
    {
        if (!await RefreshTokenRepository.IsRequestTokenValid(req.LongUserId, req.RefreshToken))
            AddError("The refresh token is not valid!");
    }

    public override Task SetRenewalPrivilegesAsync(Request request, UserPrivileges privileges)
    {
        // No authorization implemented for now (i have public and user wide methods only)
        return Task.CompletedTask;
    }
}
