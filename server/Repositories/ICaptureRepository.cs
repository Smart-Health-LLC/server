using System.Text.RegularExpressions;

namespace server.Repositories;

public interface ICaptureRepository
{
    Task Create(Capture capture);
    Task<IEnumerable<Capture>> GetAll();
    Task<Capture> GetById(int id);
    Task<IEnumerable<Capture>> GetAllByUserId(int userId);
}