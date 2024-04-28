namespace server.Domain.User;

public interface IUserRepository : IRepository<User>
{
    Task<bool> IsUsernameTaken(string username);
}
