using FastEndpoints;
using server.Domain.User;

namespace server.API.Features.Account.Signup;

public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request r)
    {
        return new User
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(r.Password),
            Username = r.Username,
            SignUpDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };
    }
}
