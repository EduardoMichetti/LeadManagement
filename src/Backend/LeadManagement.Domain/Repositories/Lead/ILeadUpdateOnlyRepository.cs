namespace LeadManagement.Domain.Repositories.Lead;
public interface ILeadUpdateOnlyRepository
{
    Task<Entities.LeadEntity?> GetById(long id);

    void Update(Entities.LeadEntity lead);
}
