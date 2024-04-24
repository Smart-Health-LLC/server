using FastEndpoints;
using server.API.Features.Account.Create;

namespace server.API.Features.Account.Signup;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("/account/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        throw new NotImplementedException();
        // var author = Map.ToEntity(r);
        //
        // var loginIsTaken = await Data.EmailAddressIsTaken(author.Email);
        //
        // if (loginIsTaken)
        //     AddError(r => r.Email, "Sorry! Email address is already in use...");
        //
        // ThrowIfAnyErrors();
        //
        // await Data.CreateNewAuthor(author);
        //
        // await SendAsync(new Response
        // {
        //     Message = "Signup complete"
        // }, cancellation: c);
    }
}
