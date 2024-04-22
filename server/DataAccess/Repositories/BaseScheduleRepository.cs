using server.DataAccess.Models;

namespace server.DataAccess.Repositories;

public class BaseScheduleRepository(DatabaseContext applicationDbContext)
    : Repository<BaseSchedule>(applicationDbContext)
{
    private readonly DatabaseContext _applicationDbContext = applicationDbContext;
}
