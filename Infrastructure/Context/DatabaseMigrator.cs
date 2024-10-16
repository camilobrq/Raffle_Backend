using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Infrastructura.Context;

public class DatabaseMigrator(IDbConnection dbConnection, ILogger<DatabaseMigrator> logger)
{
    private readonly IDbConnection _dbConnection = dbConnection;
    private readonly ILogger<DatabaseMigrator> _logger = logger;

    public async Task MigrateAsync(IEnumerable<string> migrationScripts)
    {
        foreach (var script in migrationScripts)
        {
            try
            {
                _logger.LogInformation("Executing migration script: {Script}", script);
                await _dbConnection.ExecuteAsync(script);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing migration script: {Script}", script);
                throw;
            }
        }
    }
}
