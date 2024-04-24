using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using server.DataAccess.Models;

namespace server.DataAccess;

public class DatabaseContext(IOptions<DbSettings> dbSettings) : DbContext
{
    private readonly DbSettings _dbSettings = dbSettings.Value;
    public DbSet<BaseSchedule> BaseSchedules { get; set; }
    public DbSet<BaseScheduleFamily> BaseScheduleFamilies { get; set; }
    public DbSet<BaseSleepPeriod> BaseSleepPeriods { get; set; }
    public DbSet<Capture> Captures { get; set; }
    public DbSet<FallingAsleepEase> FallingAsleepMarks { get; set; }
    public DbSet<MissedCheck> MissedChecks { get; set; }
    public DbSet<Oversleep> Oversleeps { get; set; }
    public DbSet<SkippedPeriod> SkippedPeriods { get; set; }
    public DbSet<SleepPeriod> SleepPeriods { get; set; }
    public DbSet<SleepPeriodHistory> SleepPeriodChanges { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserNote> UserNotes { get; set; }
    public DbSet<UserScheduleAttempt> UserScheduleAttempts { get; set; }
    public DbSet<WakingUpEase> WakingUpMarks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            $"Host={_dbSettings.Server}; Database={_dbSettings.Database}; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
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
