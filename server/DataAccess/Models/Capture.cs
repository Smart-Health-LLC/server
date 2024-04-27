using System.ComponentModel.DataAnnotations;

namespace server.DataAccess.Models;

public class Capture
{
    [Key] public long Id { get; set; }

    public virtual User User { get; set; }

    public DateTime? StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string TypeName { get; set; }
    public double Value { get; set; }
}
