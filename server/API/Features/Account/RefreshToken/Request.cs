using FastEndpoints.Security;

namespace server.API.Features.Account.RefreshToken;

public class Request : TokenRequest
{
    // UserId is stored as integer value
    public int IntUserId => int.Parse(UserId);
}
