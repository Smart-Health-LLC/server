using FastEndpoints;
using FastEndpoints.Security;
using server.DataAccess.Interfaces;

namespace server.API.Features.Account.RefreshToken;

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

    public IRefreshTokenRepository RefreshTokenRepository { get; set; }

    public override Task PersistTokenAsync(Response rsp)
    {
        return RefreshTokenRepository.StoreToken(rsp.IntUserId, rsp.RefreshExpiry, rsp.RefreshToken);
    }

    public override async Task RefreshRequestValidationAsync(Request req)
    {
        if (!await RefreshTokenRepository.IsRequestTokenValid(req.IntUserId, req.RefreshToken))
            AddError("The refresh token is not valid!");
    }

    public override Task SetRenewalPrivilegesAsync(Request request, UserPrivileges privileges)
    {
        // No authorization implemented for now (i have public and user wide methods only)
        return Task.CompletedTask;
    }
}
