namespace server.Models;

public class BaseScheduleFamily
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<BaseSchedule> Schedules { get; set; }
}
