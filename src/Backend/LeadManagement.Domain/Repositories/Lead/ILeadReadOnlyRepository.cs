using LeadManagement.Domain.Dto;
using LeadManagement.Domain.Enums;

namespace LeadManagement.Domain.Repositories.Lead;
public interface ILeadReadOnlyRepository
{
    public Task<bool> ExistActiveLeadWithEmail(string email);

    public Task<Entities.LeadEntity?> GetLeadByStatus(LeadStatus status);

    Task<IList<Entities.LeadEntity>> FilterList(FilterLeadsDto filters);
}
