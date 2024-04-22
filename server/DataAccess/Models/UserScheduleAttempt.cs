using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class UserScheduleAttempt
{
    public int Id { get; set; }

    [ForeignKey("BaseScheduleId")] public BaseSchedule BaseSchedule { get; set; }

    public bool IsArchived { get; set; }
    public bool IsAdopted { get; set; }

    [ForeignKey("UserNoteId")] public List<UserNote> Notes { get; set; }
}
