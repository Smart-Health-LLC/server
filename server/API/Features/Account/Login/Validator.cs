using FastEndpoints;
using FluentValidation;

namespace server.API.Features.Account.Login;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required!");
    }
}
