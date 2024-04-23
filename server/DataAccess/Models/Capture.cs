using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class Capture
{
    [Key] public int Id { get; set; }

    [ForeignKey("UserId")] public virtual User User { get; set; }

    public DateTime? StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string TypeName { get; set; }
    public double Value { get; set; }
}
