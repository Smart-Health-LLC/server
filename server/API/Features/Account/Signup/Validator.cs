using FastEndpoints;
using FluentValidation;
using server.API.Features.Account.Create;

namespace server.API.Features.Account.Signup;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("your name is required!")
            .MinimumLength(4).WithMessage("name is too short!")
            .MaximumLength(25).WithMessage("name is too long!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("a password is required!")
            .MinimumLength(8).WithMessage("password is too short!")
            .MaximumLength(25).WithMessage("password is too long!");
    }
}
