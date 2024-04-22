using System.ComponentModel.DataAnnotations;

namespace server.Business.DTO;

public class CreateSetCaptureRequest
{
    [Required] public List<CreateCaptureRequest> captures { get; set; }
}
