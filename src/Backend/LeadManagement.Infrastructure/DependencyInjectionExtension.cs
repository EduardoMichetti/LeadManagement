using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Repositories;
using LeadManagement.Domain.Repositories.Lead;
using LeadManagement.Domain.Services;
using LeadManagement.Infrastructure.DataAccess;
using LeadManagement.Infrastructure.DataAccess.Repositories;
using LeadManagement.Infrastructure.Extensions;
using LeadManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeadManagement.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseType = configuration.DatabaseType();

        if (databaseType == DatabaseType.SqlServer)
        {
            AddDbContext_SqlServer(services, configuration);
        }
        AddRepositories(services);
    }

    private static void AddDbContext_SqlServer(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();

        services.AddDbContext<LeadManagementDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILeadReadOnlyRepository, LeadRepository>();
        services.AddScoped<ILeadWriteOnlyRepository, LeadRepository>();
        services.AddScoped<ILeadUpdateOnlyRepository, LeadRepository>();
        services.AddScoped<IFileGenerationService, FileGenerationService>();
    }

}
