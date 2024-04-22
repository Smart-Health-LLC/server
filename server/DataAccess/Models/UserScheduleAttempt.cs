namespace server.DataAccess.Models;

public class UserScheduleAttempt
{
    public int Id { get; set; }
    public BaseSchedule BaseSchedule { get; set; }
    public bool IsArchived { get; set; }
    public bool IsAdopted { get; set; }
    public List<UserNote> Notes { get; set; }
}
