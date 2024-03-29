namespace server.Models;

public class Capture
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string TypeName { get; set; }
    public double Value { get; set; }
}