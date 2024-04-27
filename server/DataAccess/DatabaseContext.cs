using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using server.DataAccess.Models;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace server.DataAccess;

public class DatabaseContext(IOptions<DbSettings> dbSettings) : DbContext
{
    private readonly DbSettings _dbSettings = dbSettings.Value;
    public DbSet<BaseSchedule> BaseSchedules { get; set; }
    public DbSet<BaseScheduleFamily> BaseScheduleFamilies { get; set; }
    public DbSet<JwtLastToken> JwtLastTokens { get; set; }
    public DbSet<BaseSleepPeriod> BaseSleepPeriods { get; set; }
    public DbSet<Capture> Captures { get; set; }
    public DbSet<FallingAsleepEase> FallingAsleepMarks { get; set; }
    public DbSet<MissedCheck> MissedChecks { get; set; }
    public DbSet<Oversleep> Oversleeps { get; set; }
    public DbSet<SkippedPeriod> SkippedPeriods { get; set; }
    public DbSet<SleepPeriod> SleepPeriods { get; set; }
    public DbSet<SleepPeriodHistory> SleepPeriodChanges { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
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
        modelBuilder.Seed();
    }
}
