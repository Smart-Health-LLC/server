namespace server.DataAccess.Models;

public class SleepPeriod
{
    public long Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsDeleted { get; set; }

    public virtual UserScheduleAttempt Attempt { get; set; }
    public virtual List<Note> Notes { get; set; }
}
