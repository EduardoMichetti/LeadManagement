using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.DataAccess;
public class LeadManagementDbContext : DbContext
{
    public LeadManagementDbContext(DbContextOptions options) : base(options) { }

    public DbSet<LeadEntity> Lead { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeadManagementDbContext).Assembly);
    }
}
