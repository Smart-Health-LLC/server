namespace server.API.Features.Attempt.Schedule.Update;
//
// public class Endpoint(IUserScheduleService scheduleService)
//     : Endpoint<Request, Results<Ok, ProblemDetails>>
// {
//     public override void Configure()
//     {
//         Post("/schedule/update/");
//     }
//
//     public override async Task<Results<Ok, ProblemDetails>> ExecuteAsync(Request req, CancellationToken c)
//     {
//         var errors = await scheduleService.UpdateSchedule(req.SleepActionsToPerform, req.UserId);
//         if (errors.Count == 0)
//             return TypedResults.Ok();
//
//         foreach (var error in errors) AddError(error);
//         return new ProblemDetails();
//     }
// }
