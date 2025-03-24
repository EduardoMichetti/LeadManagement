using LeadManagement.Domain.Repositories;

namespace LeadManagement.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly LeadManagementDbContext _dbContext;
    public UnitOfWork(LeadManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
