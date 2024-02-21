using System.Text.RegularExpressions;

namespace server.Services;

public interface ICaptureService
{
    Task<IEnumerable<Capture>> GetAll();
    Task<Capture> GetById(int id);
}