using System.Text.RegularExpressions;
using server.DTO;

namespace server.Services;

public interface ICaptureService
{
    Task<IEnumerable<Capture>> GetAll();
    Task<Capture> GetById(int id);
    Task Create(CreateCaptureRequest model);
    Task Create(CreateSetCaptureRequest model);
}
