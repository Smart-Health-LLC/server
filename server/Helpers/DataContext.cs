using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace server.Helpers;

public class DataContext(IOptions<DbSettings> dbSettings)
{
    private readonly DbSettings _dbSettings = dbSettings.Value;

    public IDbConnection CreateConnection()
    {
        var connectionString =
            $"Host={_dbSettings.Server}; Database={_dbSettings.Database}; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
        return new NpgsqlConnection(connectionString);
    }

    public async Task Init()
    {
        await _initDatabase();
        await _initTables();
    }

    private async Task _initDatabase()
    {
        // create database if it doesn't exist
        var connectionString =
            $"Host={_dbSettings.Server}; Database=postgres; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";

        await using var connection = new NpgsqlConnection(connectionString);
        var sqlDbCount = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{_dbSettings.Database}';";
        var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCount);
        if (dbCount == 0)
        {
            var sql = $"CREATE DATABASE \"{_dbSettings.Database}\"";
            await connection.ExecuteAsync(sql);
        }
    }

    private async Task _initTables()
    {
        // create tables if they don't exist
        using var connection = CreateConnection();
        await _initUsers();
        await _initCaptures();

        async Task _initUsers()
        {
            var sql = """
                          CREATE TABLE IF NOT EXISTS Users (
                              Id SERIAL PRIMARY KEY,
                              UserId SERIAL FOREIGN KEY
                              Title VARCHAR,
                              FirstName VARCHAR,
                              LastName VARCHAR,
                              Email VARCHAR,
                              Role INTEGER,
                              PasswordHash VARCHAR
                          );
                      """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initCaptures()
        {
            var sql = """
                          CREATE TABLE IF NOT EXISTS Captures (
                              Id SERIAL PRIMARY KEY,
                              StartTime TIMESTAMP,
                              EndTime TIMESTAMP,
                              TypeName VARCHAR,
                              Value REAL
                          );
                      """;
            await connection.ExecuteAsync(sql);
        }
    }
}