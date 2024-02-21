namespace server.Models;

public class Capture
{
    public int Id { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Type { get; set; }
    public double Value { get; set; }
}