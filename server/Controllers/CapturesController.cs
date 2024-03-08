using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class CapturesController(ICaptureService captureService, ILogger<UsersController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var captures = await captureService.GetAll();
        return Ok(captures);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var capture = await captureService.GetById(id);
        return Ok(capture);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCaptureRequest model)
    {
        await captureService.Create(model);
        logger.Log(LogLevel.Information, "New capture saved");
        return Ok(new { message = "Capture saved" });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSetCaptureRequest model)
    {
        await captureService.Create(model);
        logger.Log(LogLevel.Information, "Set of new captures saved");
        return Ok(new { message = "Set of new captures saved" });
    }
}
