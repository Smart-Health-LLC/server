using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await userService.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRequest model)
    {
        await userService.Create(model);
        return Ok(new { message = "User created" });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateRequest model)
    {
        await userService.Update(id, model);
        return Ok(new { message = "User updated" });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await userService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}