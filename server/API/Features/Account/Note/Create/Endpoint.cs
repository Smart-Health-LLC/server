using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using server.Domain;

namespace server.API.Features.Account.Note.Create;

public class Endpoint(IRepository<Domain.UserScheduleManagement.Note> notesRepository)
    : Endpoint<Request, Results<Ok, ProblemDetails>>
{
    public override void Configure()
    {
        Post("/account/note/create/");
    }

    public override async Task<Results<Ok, ProblemDetails>> ExecuteAsync(Request req, CancellationToken c)
    {
        await notesRepository.CreateAsync(new Domain.UserScheduleManagement.Note
        {
            Content = req.NoteContent,
            CreatedAt = DateTime.UtcNow
        });
        return TypedResults.Ok();
    }
}