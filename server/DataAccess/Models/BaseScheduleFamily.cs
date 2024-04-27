using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.DataAccess.Models;

public class BaseScheduleFamily
{
    public long Id { get; set; }

    [MaxLength(100)] public string Name { get; set; }

    // localized value is stored in resource files on the server separately
    [NotMapped] public string? Description { get; set; }

    public virtual List<BaseSchedule> BaseSchedules { get; set; }
}
