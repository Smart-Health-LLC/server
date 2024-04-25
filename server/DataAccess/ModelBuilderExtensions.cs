using Microsoft.EntityFrameworkCore;
using server.DataAccess.Models;

namespace server.DataAccess;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // TODO add base schedule data and other predefined stuff
        modelBuilder.Entity<BaseScheduleFamily>().HasData(
            new BaseScheduleFamily
            {
                Id = 1,
                Name = "Biphasic",
                Schedules = []
            },
            new BaseScheduleFamily
            {
                Id = 2,
                Name = "Everyman",
                Schedules = []
            },
            new BaseScheduleFamily
            {
                Id = 3,
                Name = "Dual core",
                Schedules = []
            },
            new BaseScheduleFamily
            {
                Id = 4,
                Name = "Tri core",
                Schedules = []
            },
            new BaseScheduleFamily
            {
                Id = 5,
                Name = "Core-only",
                Schedules = []
            },
            new BaseScheduleFamily
            {
                Id = 6,
                Name = "Nap-only",
                Schedules = []
            },
            new BaseScheduleFamily
            {
                Id = 7,
                Name = "Flexible",
                Schedules = []
            },
            new BaseScheduleFamily
            {
                Id = 8,
                Name = "Non-reducing",
                Schedules = []
            }
        );
    }
}
