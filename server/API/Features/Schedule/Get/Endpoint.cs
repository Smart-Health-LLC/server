namespace server.API.Features.Schedule.Get;

// public class Endpoint(
//     IRepository<SleepPeriod> sleepPeriodRepository,
//     IRepository<UserScheduleAttempt> attemptRepository)
//     : EndpointWithoutRequest<Results<Ok<List<SleepPeriod>>, ProblemDetails>>
// {
//     public override void Configure()
//     {
//         Get("/schedule/get/");
//         Summary(s =>
//         {
//             s.Summary = "Gets user's schedule attempt";
//             s.Description = "Gets user's schedule attempt";
//         });
//     }
//
//
//     public override Task<Results<Ok<List<SleepPeriod>>, ProblemDetails>> ExecuteAsync(
//         CancellationToken ct)
//     {
//         // attemptRepository.GetAsync(attempt => { attempt })
//         // sleepPeriodRepository.GetAllAsync(period => { period.Attempt.Id == })
//         // return Task.CompletedTask()
//         // return TypedResults.Ok();
//     }
// }
