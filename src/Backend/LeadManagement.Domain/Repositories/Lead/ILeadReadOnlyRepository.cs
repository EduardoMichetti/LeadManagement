using LeadManagement.Domain.Dto;

namespace LeadManagement.Domain.Repositories.Lead;
public interface ILeadReadOnlyRepository
{
    public Task<bool> ExistActiveLeadWithEmail(string email);

    Task<Entities.LeadEntity?> GetById(long id);

    Task<IList<Entities.LeadEntity>> FilterList(FilterLeadsDto filters);
}
