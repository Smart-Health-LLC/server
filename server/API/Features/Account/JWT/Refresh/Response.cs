using FastEndpoints.Security;

namespace server.API.Features.Account.JWT.Refresh;

public class Response : TokenResponse
{
    // As it's internal string no culture can be set here
    // ReSharper disable once SpecifyACultureInStringConversionExplicitly
    public string AccessTokenExpiry => AccessExpiry.ToLocalTime().ToString();

    public int RefreshTokenValidityMinutes => (int)RefreshExpiry.Subtract(DateTime.UtcNow).TotalMinutes;

    // UserId is stored as integer value
    public int IntUserId => int.Parse(UserId);
}
