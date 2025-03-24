using LeadManagement.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace LeadManagement.Infrastructure.Extensions;
public static class ConfigurationExtension
{
    public static DatabaseType DatabaseType(this IConfiguration configuration)
    {
        var databaseType = configuration.GetConnectionString("DatabaseType");
        return (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseType!);
    }

    public static string ConnectionString(this IConfiguration configuration)
    {
        var databaseType = configuration.DatabaseType();

        if (databaseType == Domain.Enums.DatabaseType.SqlServer)
        {
            return configuration.GetConnectionString("ConnectionSQLServer")!;
        }
        return string.Empty;
    }
}
