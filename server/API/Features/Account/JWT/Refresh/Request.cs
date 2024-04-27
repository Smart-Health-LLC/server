using FastEndpoints.Security;

namespace server.API.Features.Account.JWT.Refresh;

public class Request : TokenRequest
{
    // UserId is stored as integer value
    public long LongUserId => long.Parse(UserId);
}
