using System.ComponentModel.DataAnnotations;

namespace server.DataAccess.Models;

public class Note
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }

    [MaxLength(1000)] public string Content { get; set; }
    public virtual List<SleepPeriod> SleepPeriods { get; set; }
}
