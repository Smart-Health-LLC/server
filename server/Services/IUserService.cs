using server.DTO;
using server.Models;

namespace server.Services;

/**
 * High-level interface to work with data taking into account validations and other checks
 */
public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task Create(CreateUserRequest model);
    Task Update(int id, UpdateRequest model);
    Task Delete(int id);
}