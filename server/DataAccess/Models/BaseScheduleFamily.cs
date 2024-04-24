using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class BaseScheduleFamily
{
    public int Id { get; set; }
    [MaxLength(100)] public string Name { get; set; }
    [MaxLength(1000)] public string? Description { get; set; }

    [ForeignKey("BaseScheduleId")] public virtual List<BaseSchedule>? Schedules { get; set; }
}
