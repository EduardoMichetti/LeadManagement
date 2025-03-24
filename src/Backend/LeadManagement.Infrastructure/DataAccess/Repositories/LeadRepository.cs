using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Repositories.Lead;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.DataAccess.Repositories;
public class LeadRepository : ILeadWriteOnlyRepository, ILeadReadOnlyRepository
{
    private readonly LeadManagementDbContext _dbContext;

    public LeadRepository(LeadManagementDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(LeadEntity lead)
    {
        await _dbContext.Leads.AddAsync(lead);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistActiveLeadWithEmail(string email) =>
        await _dbContext.Leads.AnyAsync(lead => lead.ContactEmail.Equals(email) && lead.Active);
}
