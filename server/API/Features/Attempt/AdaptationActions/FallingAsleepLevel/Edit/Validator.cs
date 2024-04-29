using FastEndpoints;
using FluentValidation;
using server.Domain.UserScheduleManagement;

namespace server.API.Features.Attempt.AdaptationActions.FallingAsleepLevel.Edit;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(req => req.NewLevel)
            .NotNull().WithMessage("level is required!")
            .InclusiveBetween(MarkConstants.MinLevel, MarkConstants.MaxLevel)
            .WithMessage($"Level should be from {MarkConstants.MinLevel} to {MarkConstants.MaxLevel}");

        RuleFor(req => req.FallingAsleepEaseLevelId).NotNull().WithMessage("id is required");
    }
}
