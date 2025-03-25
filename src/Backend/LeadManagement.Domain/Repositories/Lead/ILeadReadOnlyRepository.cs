using LeadManagement.Domain.Enums;

namespace LeadManagement.Domain.Repositories.Lead;
public interface ILeadReadOnlyRepository
{
    public Task<bool> ExistActiveLeadWithEmail(string email);

    public Task<Entities.LeadEntity?> GetLeadByStatus(LeadStatus status);

    public Task<IEnumerable<Entities.LeadEntity?>> GetStatus();
}
