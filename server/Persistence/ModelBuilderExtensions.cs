using Microsoft.EntityFrameworkCore;
using server.Domain.BaseSchedule;

namespace server.Persistence;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        long baseSleepPeriodId = 1;
        long baseScheduleId = 1;
        long baseScheduleFamilyId = 1;
        // TODO add base schedule data and other predefined stuff
        // Base schedules
        // Biphasic
        var biphasicX = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "BiphasicX",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var siesta = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Siesta",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var siestaExt = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Siesta Ext",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        // Dual core
        var bimaxion = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Bimaxion",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        // Everyman
        var e1 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Everyman 1",
            ShortName = "E1",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var e1Ext = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Everyman 1 Ext",
            ShortName = "E1-ext",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var e2 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Everyman 2",
            ShortName = "E2",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var e3 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Everyman 3",
            ShortName = "E3",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var e3Ext = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Everyman 3 Ext",
            ShortName = "E3-ext",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var e4 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Everyman 4",
            ShortName = "E4",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var e5 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Everyman 5",
            ShortName = "E5",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        // Nap only
        var dymaxion = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Dymaxion",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        // Dual core
        var dc1 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Dual Core 1",
            ShortName = "DC1",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var dc1Ext = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Dual Core 1 Ext",
            ShortName = "DC1-ext",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var dc2 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Dual Core 2",
            ShortName = "DC2",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var dc3 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Dual Core 3",
            ShortName = "DC3",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var dc4 = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Dual Core 4",
            ShortName = "DC4",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        // Tri core
        var triphasic = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Triphasic",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var triphasicExt = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Triphasic Ext",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        // Core only
        var segmented = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Segmented",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        var segmentedExt = new BaseSchedule
        {
            Id = baseScheduleId++,
            TotalSleepTime = TimeSpan.FromHours(5),
            Name = "Segmented Ext",
            ShortName = "",
            Description = "",
            SleepPeriods =
            [
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod
                    { Id = baseSleepPeriodId++, StartTime = GetRandomTime(), EndTime = GetRandomTime() },
                new BaseSleepPeriod { Id = baseSleepPeriodId, StartTime = GetRandomTime(), EndTime = GetRandomTime() }
            ]
        };

        // Families 
        var biphasic = new BaseScheduleFamily
        {
            Id = baseScheduleFamilyId++,
            Name = "Biphasic",
            BaseSchedules = [biphasicX, siestaExt, siesta]
        };

        var everyman = new BaseScheduleFamily
        {
            Id = baseScheduleFamilyId++,
            Name = "Everyman",
            BaseSchedules = [e1, e1Ext, e2, e3, e3Ext, e1Ext, e4, e5]
        };

        var dualCore = new BaseScheduleFamily
        {
            Id = baseScheduleFamilyId++,
            Name = "Dual core",
            BaseSchedules = [bimaxion, dc1, dc2, dc1Ext, dc3, dc4]
        };

        var triCore = new BaseScheduleFamily
        {
            Id = baseScheduleFamilyId++,
            Name = "Tri core",
            BaseSchedules = [triphasic, triphasicExt]
        };

        var coreOnly = new BaseScheduleFamily
        {
            Id = baseScheduleFamilyId++,
            Name = "Core-only",
            BaseSchedules = [segmented, segmentedExt]
        };

        var napOnly = new BaseScheduleFamily
        {
            Id = baseScheduleFamilyId++,
            Name = "Nap-only",
            BaseSchedules = [dymaxion]
        };

        var flexible = new BaseScheduleFamily
        {
            Id = baseScheduleFamilyId++,
            Name = "Flexible",
            BaseSchedules = []
        };

        var nonReducing = new BaseScheduleFamily
        {
            Id = baseScheduleFamilyId,
            Name = "Non-reducing",
            BaseSchedules = []
        };

        List<BaseSchedule> baseSchedules =
        [
            biphasicX, siesta, siestaExt, bimaxion, e1, e1Ext, e2, e3, e3Ext, e4, e5, dymaxion, dc1, dc1Ext, dc2, dc3,
            dc4, triphasic, triphasicExt, segmented, segmentedExt
        ];

        List<BaseScheduleFamily> baseScheduleFamilies =
        [
            biphasic, everyman, dualCore, triCore, coreOnly, napOnly, flexible, nonReducing
        ];

        //  The exception 'The seed entity for entity type 'BaseScheduleFamily' with the key value 'Id:1' cannot be
        // added because it has the navigation 'BaseSchedules' set. To seed relationships, add the entity seed to
        // 'BaseSchedule' and specify the foreign key values {'BaseScheduleFamilyId'}.' was thrown while attempting to
        // create an instance.
        foreach (var baseScheduleFamily in baseScheduleFamilies)
        {
            foreach (var baseSchedule in baseScheduleFamily.BaseSchedules)
                baseSchedule.BaseScheduleFamilyId = baseScheduleFamily.Id;
            baseScheduleFamily.BaseSchedules = null!;
        }


        var baseSleepPeriods = baseSchedules.SelectMany(schedule => schedule.SleepPeriods).ToList();

        modelBuilder.Entity<BaseSleepPeriod>().HasData(
            baseSleepPeriods
        );


        foreach (var baseSchedule in baseSchedules)
        {
            foreach (var baseScheduleSleepPeriod in baseSchedule.SleepPeriods)
                baseScheduleSleepPeriod.BaseScheduleId = baseSchedule.Id;
            baseSchedule.SleepPeriods = null!;
        }

        modelBuilder.Entity<BaseSchedule>().HasData(
            baseSchedules
        );

        modelBuilder.Entity<BaseScheduleFamily>().HasData(
            biphasic, everyman, dualCore, triCore, coreOnly, napOnly, flexible, nonReducing
        );
        return;


        TimeOnly GetRandomTime()
        {
            var random = new Random();
            var hours = random.Next(0, 24);
            var minutes = random.Next(0, 60);
            var seconds = random.Next(0, 60);
            return new TimeOnly(hours, minutes, seconds);
        }
    }
}
