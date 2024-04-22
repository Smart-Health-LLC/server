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
        // modelBuilder.Entity<Villa>().HasData(
        //     new Villa
        //     {
        //         Id = 1, Amenity = "Pool", CreatedDate = DateTime.Now, Details = "This is a 3 bedroom villa",
        //         ImageUrl = "https://www.villarenters.com/content/images/properties/property_1/property_1_1.jpg",
        //         Name = "Villa 1", Occupancy = 6, Rate = 1000, Sqft = 2000, UpdatedDate = DateTime.Now
        //     },
        // );
    }
}
