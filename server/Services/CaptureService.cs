using AutoMapper;
using server.DTO;
using server.Repositories;
using Capture = System.Text.RegularExpressions.Capture;

namespace server.Services;

public class CaptureService(
    ICaptureRepository captureRepository,
    IMapper mapper
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


    public async Task Create(CreateCaptureRequest model)
    {
        // map model to new capture object
        var capture = mapper.Map<Capture>(model);

        // save capture
        await captureRepository.Create(capture);
    }

    public async Task<IEnumerable<Capture>> GetAllByUserId(int userId)
    {
        return await captureRepository.GetAllByUserId(userId);
    }
}