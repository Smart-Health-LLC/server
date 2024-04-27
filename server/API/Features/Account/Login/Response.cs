using server.API.Features.Account.JWT;

namespace server.API.Features.Account.Login;

public class Response
{
    public JwtToken Token { get; set; } = new();
}
