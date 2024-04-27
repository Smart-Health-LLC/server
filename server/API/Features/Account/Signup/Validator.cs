using FastEndpoints;
using FluentValidation;
using server.DataAccess.Models;

namespace server.API.Features.Account.Signup;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("your name is required!")
            .MinimumLength(User.UsernameMinLength).WithMessage("name is too short!")
            .MaximumLength(User.UsernameMaxLength).WithMessage("name is too long!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("a password is required!")
            .MinimumLength(8).WithMessage("password is too short!")
            .MaximumLength(25).WithMessage("password is too long!");
    }
}
