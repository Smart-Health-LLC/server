using FastEndpoints;
using FastEndpoints.Security;
using server.DataAccess.Interfaces;
using server.DataAccess.Models;

namespace server.API.Features.Account.Login;

public class Endpoint(IRepository<User> repository) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/account/login/");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var user = await repository.GetAsync(u => u.Username == req.Username);

        if (user is null)
            ThrowError("Username not found");

        if (user?.PasswordHash is null || !BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
            ThrowError("Invalid login credentials!");

        Response.Token.Value = JwtBearer.CreateToken(
            o =>
            {
                o.SigningKey = Config["JwtSigningKey"]!;
                o.ExpireAt = DateTime.UtcNow.AddHours(4);
            });
    }
}
