using System.ComponentModel.DataAnnotations;

namespace server.DTO;

public class CreateCaptureRequest
{
    [Required] public int? UserId { get; set; }

    public DateTime? StartTime { get; set; }

    [Required] public DateTime? EndTime { get; set; }

    [Required] public string? TypeName { get; set; }

    [Required] public double? Value { get; set; }
}