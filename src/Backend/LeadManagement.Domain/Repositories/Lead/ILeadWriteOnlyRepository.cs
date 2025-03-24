using LeadManagement.Domain.Entities;

namespace LeadManagement.Domain.Repositories.Lead;
public interface ILeadWriteOnlyRepository
{
    public Task Add(LeadEntity lead);
}
