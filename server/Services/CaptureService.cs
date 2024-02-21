using System.Text.RegularExpressions;
using server.Repositories;

namespace server.Services;

public class CaptureService(
    ICaptureRepository captureRepository
) : ICaptureService
{
    public async Task<IEnumerable<Capture>> GetAll()
    {
        return await captureRepository.GetAll();
    }

    public async Task<Capture> GetById(int id)
    {
        var capture = await captureRepository.GetById(id);

        if (capture == null) throw new KeyNotFoundException("Capture not found");

        return capture;
    }
}