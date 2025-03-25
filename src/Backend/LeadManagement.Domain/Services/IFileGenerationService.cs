using LeadManagement.Domain.Entities;

namespace LeadManagement.Domain.Services;
public interface IFileGenerationService
{
    Task GenerateFileAsync(LeadEntity lead);
}
