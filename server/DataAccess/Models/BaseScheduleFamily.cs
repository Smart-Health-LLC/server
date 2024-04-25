using System.ComponentModel.DataAnnotations;

namespace server.DataAccess.Models;

public class BaseScheduleFamily
{
    public int Id { get; set; }
    [MaxLength(100)] public string Name { get; set; }
    [MaxLength(1000)] public string? Description { get; set; }

    public virtual List<BaseSchedule>? Schedules { get; set; }
}
