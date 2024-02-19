using server.Models;

namespace server.Repositories;

/**
 * Strait up interface for low-level work with data
 */
public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task<User> GetByEmail(string email);
    Task Create(User user);
    Task Update(User user);
    Task Delete(int id);
}