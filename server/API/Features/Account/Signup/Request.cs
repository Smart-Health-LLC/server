#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace server.API.Features.Account.Signup;

public class Request
{
    public string Username { get; set; }
    public string Password { get; set; }
}
