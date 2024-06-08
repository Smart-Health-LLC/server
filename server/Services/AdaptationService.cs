using server.Domain;
using server.Domain.UserSchedule;
using server.Domain.UserScheduleManagement;

namespace server.Services;

public class AdaptationService(
    IRepository<SleepPeriod> sleepPeriodRepository,
    IRepository<FallingAsleepEase> fallingAsleepEaseRepository,
    IRepository<Oversleep> oversleepRepository) : IAdaptationService
{
}
