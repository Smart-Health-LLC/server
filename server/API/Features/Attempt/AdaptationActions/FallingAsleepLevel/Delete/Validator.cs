using FastEndpoints;
using FluentValidation;

namespace server.API.Features.Attempt.AdaptationActions.FallingAsleepLevel.Delete;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(req => req.MarkId).NotNull().WithMessage("mark id is required");
    }
}
