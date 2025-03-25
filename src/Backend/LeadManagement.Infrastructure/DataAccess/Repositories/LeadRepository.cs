using LeadManagement.Domain.Dto;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Repositories.Lead;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.DataAccess.Repositories;
public class LeadRepository : ILeadWriteOnlyRepository, ILeadReadOnlyRepository, ILeadUpdateOnlyRepository
{
    private readonly LeadManagementDbContext _dbContext;

    public LeadRepository(LeadManagementDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(LeadEntity lead) => await _dbContext.Lead.AddAsync(lead);

    public async Task<bool> ExistActiveLeadWithEmail(string email) =>
        await _dbContext
            .Lead.AnyAsync(lead => lead.ContactEmail.Equals(email) 
                && lead.Active);

    public async Task<LeadEntity?> GetLeadByStatus(LeadStatus status)
    {
        return await _dbContext
            .Lead
            .FirstOrDefaultAsync(lead => lead.Status.Equals(status)
                && lead.Active);
    }

    public async Task<IList<LeadEntity>> FilterList(FilterLeadsDto filters)
    {
        var query = _dbContext
            .Lead
            .AsNoTracking()
            .Where(lead => lead.Active 
                && lead.Status.Equals(filters.Status));

        return await query.ToListAsync();
    }

    public async Task<LeadEntity?> GetById(long id)
    {
        return await _dbContext
            .Lead
            .FirstOrDefaultAsync(lead => lead.Active
                             && lead.Id == id);
    }

    public void Update(LeadEntity lead)
    {
        _dbContext.Lead.Update(lead);
    }
}
