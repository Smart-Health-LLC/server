#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.API.Features.Account.JWT;

public class JwtToken
{
    public string Value { get; set; }
    public DateTime ExpiryDate { get; set; }
}
