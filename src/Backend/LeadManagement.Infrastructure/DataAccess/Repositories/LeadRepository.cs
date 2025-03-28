﻿using LeadManagement.Domain.Dto;
using LeadManagement.Domain.Entities;
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

    public async Task<IList<LeadEntity>> FilterList(FilterLeadsDto filters)
    {
        var query = _dbContext
            .Lead
            .AsNoTracking()
            .Where(lead => lead.Active
                && lead.Status.Equals(filters.Status));

        return await query.ToListAsync();
    }

    async Task<LeadEntity?> ILeadReadOnlyRepository.GetById(long id)
    {
        return await _dbContext
            .Lead
            .AsNoTracking()
            .FirstOrDefaultAsync(lead => lead.Active
                             && lead.Id == id);
    }

    async Task<LeadEntity?> ILeadUpdateOnlyRepository.GetById(long id)
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
