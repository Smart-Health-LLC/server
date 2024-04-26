namespace server.DataAccess.Models;

public class UserScheduleAttempt
{
    public int Id { get; set; }

    public virtual BaseSchedule BaseSchedule { get; set; }

    public bool IsArchived { get; set; }
    public bool IsAdopted { get; set; }
    public DateOnly DateStarted { get; set; }
    public DateOnly DateFinished { get; set; }

    public virtual List<Note> Notes { get; set; }
}
