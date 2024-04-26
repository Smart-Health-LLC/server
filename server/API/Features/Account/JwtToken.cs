namespace server.API.Features.Account;

public class JwtToken
{
    public string Value { get; set; }
    public DateTime ExpiryDate { get; set; }
}
