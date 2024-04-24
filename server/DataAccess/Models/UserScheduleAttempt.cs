using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class UserScheduleAttempt
{
    public int Id { get; set; }

    [ForeignKey("BaseScheduleId")] public virtual BaseSchedule BaseSchedule { get; set; }

    public bool IsArchived { get; set; }
    public bool IsAdopted { get; set; }
    public DateOnly DateStarted { get; set; }
    public DateOnly DateFinished { get; set; }

    [ForeignKey("UserNoteId")] public virtual List<UserNote> Notes { get; set; }
}
