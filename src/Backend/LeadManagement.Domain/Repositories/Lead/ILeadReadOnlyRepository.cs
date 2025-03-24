namespace LeadManagement.Domain.Repositories.Lead;
public interface ILeadReadOnlyRepository
{
    public Task<bool> ExistActiveLeadWithEmail(string email);
}
