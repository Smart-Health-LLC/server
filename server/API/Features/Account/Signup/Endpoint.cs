using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain.User;

namespace server.API.Features.Account.Signup;

public class Endpoint(IUserRepository userRepository) : Endpoint<Request, Results<Ok<Response>, ProblemDetails>, Mapper>
{
    public override void Configure()
    {
        // "Account" namespace is chosen to make difference between namespace name "User" and entity "User"
        Post("/account/signup");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<Response>, ProblemDetails>> ExecuteAsync(Request r, CancellationToken c)
    {
        var user = Map.ToEntity(r);

        var usernameIsTaken = await userRepository.IsUsernameTaken(user.Username);

        if (usernameIsTaken)
        {
            AddError(request => request.Username, "Sorry! Username is already in use...");
            return new ProblemDetails(ValidationFailures);
        }

        ThrowIfAnyErrors();

        await userRepository.AddAsync(user, true);

        return TypedResults.Ok(new Response { Message = "Signup complete" });
    }
}
