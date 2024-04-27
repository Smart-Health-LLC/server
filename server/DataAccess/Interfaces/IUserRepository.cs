using server.DataAccess.Models;

namespace server.DataAccess.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<bool> IsUsernameTaken(string username);
}
