using Microsoft.EntityFrameworkCore;
using server.Domain;
using server.Domain.BaseSchedule;
using server.Domain.UserSchedule;

namespace server.Services;

public class UserScheduleService(
    DbContext dbContext,
    IRepository<BaseSchedule> baseScheduleRepository,
    IUserScheduleAttemptRepository userScheduleAttemptRepository,
    IRepository<SleepPeriod> sleepPeriodRepository) : IUserScheduleService
{
    /**
     * Creates new schedule attempt and copies base sleep periods to separate SleepPeriods table
     */
    public async Task<bool> StartNewAttempt(long baseScheduleId, long userId)
    {
        var activeAttempt = await userScheduleAttemptRepository.GetActive(userId);

        // can't start new attempt when the active one still exists
        if (activeAttempt is not null)
            return false;


        var baseSleepPeriods =
            await sleepPeriodRepository.GetAllAsync(period => period.UserScheduleAttemptId == activeAttempt!.Id, false);

        // if base schedule id is incorrect, no sleep periods found
        if (baseSleepPeriods.Count == 0)
            return false;


        var newAttempt = new UserScheduleAttempt
        {
            UserId = userId,
            BaseScheduleId = baseScheduleId
        };

        await userScheduleAttemptRepository.AddAsync(newAttempt);
        await sleepPeriodRepository.AddCollectionAsync(baseSleepPeriods);
        await dbContext.SaveChangesAsync();

        return true;
    }

    /**
     * Gets list of sleep period of active attempt
     */
    public async Task<List<SleepPeriod>?> GetSchedule(long userId, bool tracked = false)
    {
        var activeAttemptId = (await userScheduleAttemptRepository.GetActive(userId))?.Id;

        // no schedule exists if no active attempt
        if (activeAttemptId is null)
            return null;

        var sleepPeriods =
            await sleepPeriodRepository.GetAllAsync(period => period.UserScheduleAttemptId == activeAttemptId, tracked);

        return sleepPeriods;
    }

    public async Task<List<string>> UpdateSchedule(List<SleepPeriodAction> sleepPeriodChanges, long userId)
    {
        var errors = new List<string>();

        var activeAttempt = await userScheduleAttemptRepository.GetActive(userId);

        if (activeAttempt is null)
        {
            errors.Add("No active attempt so no schedule to update. Start a new attempt first.");
            return errors;
        }

        // todo I'm sorry (maybe) for not using repository to get schedule but I can't think right now 
        var currentPeriods = dbContext.Set<SleepPeriod>()
            .Where(period => period.UserScheduleAttemptId == activeAttempt.Id);


        // apply changes to current periods and validate (yeah, I'll move the validation out of here later) sleep changes 
        // I just wanna see how it gonna be now in any (not even clean) way
        // todo check also that start time is always less than end time (keep in mind that for eg start time can be in change record and end time in existing record from db)
        foreach (var sleepPeriodChange in sleepPeriodChanges)
            if (sleepPeriodChange.IsDeleted)
            {
                if (sleepPeriodChange.Id is null)
                {
                    errors.Add("Deleted period hasn't Id");
                }
                else
                {
                    var matchingCurrentPeriod = currentPeriods!.FirstOrDefault(p => p.Id == sleepPeriodChange.Id);

                    if (matchingCurrentPeriod is null)
                        errors.Add("Period that is marked to delete has wrong id: no period with provided id exists");
                    else
                        matchingCurrentPeriod.IsDeleted = true;
                }
            }
            else if (sleepPeriodChange.IsCreated)
            {
                if (sleepPeriodChange.StartTime is null || sleepPeriodChange.EndTime is null)
                    errors.Add("Created sleep period doesn't have start or end time");
                else
                    dbContext.Add(new SleepPeriod
                    {
                        // I have to cast even after null checks..... idk wtf
                        UserScheduleAttemptId = activeAttempt.Id,
                        StartTime = (TimeOnly)sleepPeriodChange.StartTime,
                        EndTime = (TimeOnly)sleepPeriodChange.EndTime
                    });
            }
            else if (sleepPeriodChange.IsChanged)
            {
                if (sleepPeriodChange.Id is null)
                {
                    errors.Add("Changed period hasn't Id");
                }
                else
                {
                    var matchingCurrentPeriod = currentPeriods!.FirstOrDefault(p => p.Id == sleepPeriodChange.Id);

                    if (matchingCurrentPeriod is null)
                    {
                        errors.Add("Period that is marked to change has wrong id: no period with provided id exists");
                    }
                    else if (matchingCurrentPeriod.IsDeleted)
                    {
                        errors.Add(
                            "Period that is marked to change is already deleted. Create new period instead of editing deleted one");
                    }
                    else if (sleepPeriodChange.StartTime is null && sleepPeriodChange.EndTime is null)
                    {
                        errors.Add(
                            "No changes to apply on period actually provided: new EndTime and StartTime provided");
                    }
                    else
                    {
                        matchingCurrentPeriod.StartTime =
                            sleepPeriodChange.StartTime ?? matchingCurrentPeriod.StartTime;
                        matchingCurrentPeriod.EndTime = sleepPeriodChange.EndTime ?? matchingCurrentPeriod.EndTime;
                    }
                }
            }

        // validation logic goes here

        // todo check overlaps
        // todo check between naps distance
        // todo I decided to use here localization service and resources and return back to endpoint error strings (maybe it's stupid idk for now)

        // example with checking total sleep time as it's the most easiest imo

        var newTst = new TimeSpan(0, 0, 0);
        foreach (var period in currentPeriods)
        {
            var interval = period.EndTime - period.StartTime;
            newTst += interval;
        }

        var baseTst =
            (await baseScheduleRepository.GetAsync(schedule => schedule.Id == activeAttempt.BaseScheduleId, false))
            !.TotalSleepTime;

        // It's ok if new schedule have just a little bit less tst from its base
        const int allowedPercent = 5;

        if (baseTst > newTst)
            // but if new schedule has too little tst in comparing to its base, that not ok (for now... I think... idk...:((( )
            if ((baseTst - newTst).Minutes / baseTst.Minutes * 100 > allowedPercent)
                errors.Add("New schedule total time sleep much less from its base");

        /*
         *
         *
         * bunch of other checks goes here
         *
         * .....
         */

        if (errors.Count == 0)
            await dbContext.SaveChangesAsync();

        return errors;
    }
}
