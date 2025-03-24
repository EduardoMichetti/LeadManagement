using Dapper;
using LeadManagement.Domain.Enums;
using Microsoft.Data.SqlClient;

namespace LeadManagement.Infrastructure.Migrations;
public static class DatabaseMigration
{
    public static void Migrate(DatabaseType databaseType, string connectionString)
    {
        if (databaseType == DatabaseType.SqlServer)
        {
            EnsureDatabaseCreated_SqlServer(connectionString);
        }
    }

    private static void EnsureDatabaseCreated_SqlServer(string connectionString)
    {
        var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

        var databaseName = connectionStringBuilder.InitialCatalog;

        connectionStringBuilder.Remove("Database");

        using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

        var parameters = new DynamicParameters();
        parameters.Add("name", databaseName);

        var records = dbConnection.Query<int>("SELECT COUNT(*) FROM sys.databases WHERE name = @name", parameters).Single();

        if (records == 0)
        {
            dbConnection.Execute($"CREATE DATABASE {databaseName}");
        }
    }
}
