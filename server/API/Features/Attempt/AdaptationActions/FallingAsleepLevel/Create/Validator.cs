using FastEndpoints;
using FluentValidation;
using server.Domain.UserScheduleManagement;

namespace server.API.Features.Attempt.AdaptationActions.FallingAsleepLevel.Create;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(req => req.Level)
            .NotNull().WithMessage("level is required!")
            .InclusiveBetween(MarkConstants.MinLevel, MarkConstants.MaxLevel)
            .WithMessage($"Level should be from {MarkConstants.MinLevel} to {MarkConstants.MaxLevel}");

        RuleFor(req => req.Day).NotNull().WithMessage("datetime is required");
        RuleFor(req => req.SleepPeriodId).NotNull().WithMessage("sleep period id is required");
    }
}
