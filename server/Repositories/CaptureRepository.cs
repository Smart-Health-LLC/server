using System.Text.RegularExpressions;
using Dapper;
using server.Helpers;

namespace server.Repositories;

public class CaptureRepository(DataContext context) : ICaptureRepository
{
    public async Task Create(Capture capture)
    {
        using var connection = context.CreateConnection();
        const string sql = """
                               INSERT INTO Captures (UserId, StartTime, EndTime, TypeName, Value)
                               VALUES (@UserId, @StartTime, @EndTime, @TypeName, @Value)
                           """;
        await connection.ExecuteAsync(sql, capture);
    }

    public async Task<IEnumerable<Capture>> GetAll()
    {
        using var connection = context.CreateConnection();
        const string sql = """
                               SELECT * FROM Captures
                           """;
        return await connection.QueryAsync<Capture>(sql);
    }

    public async Task<Capture> GetById(int id)
    {
        using var connection = context.CreateConnection();
        const string sql = """
                               SELECT * FROM Captures
                               WHERE Id = @id
                           """;
        return await connection.QuerySingleOrDefaultAsync<Capture>(sql, new { id });
    }
}