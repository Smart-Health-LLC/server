using System.ComponentModel.DataAnnotations;

namespace server.DTO;

public class CreateSetCaptureRequest
{
    [Required] public List<CreateCaptureRequest> captures { get; set; }
}
