using FastEndpoints;
using server.API.Features.Account.Create;
using server.DataAccess.Models;

namespace server.API.Features.Account.Signup;

public class Mapper : Mapper<Request, Response, User>
{
    public override User ToEntity(Request r)
    {
        return new User
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(r.Password),
            Username = r.Login,
            SignUpDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };
    }
}
