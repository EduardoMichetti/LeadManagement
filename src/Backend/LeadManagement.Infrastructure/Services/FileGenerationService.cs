using System.Diagnostics;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Services;

namespace LeadManagement.Infrastructure.Services;
public class FileGenerationService : IFileGenerationService
{
    public async Task GenerateFileAsync(LeadEntity lead)
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        var fileName = $"Lead_{lead.Id}.txt";
        var content = $"Subject: Lead Update Notification\n\n" +
                      $"Dear {lead.ContactFirstName},\n\n" +
                      $"We are pleased to inform you that the status of your lead has been updated.\n\n" +
                      $"Lead Details:\n" +
                      $"Job ID: {lead.Id}\n" +
                      $"Status: {lead.Status}\n" +
                      $"Contact full name: {lead.ContactFullName}\n" +
                      $"Contact email : {lead.ContactEmail}\n" +
                      $"Contact phone number: {lead.ContactPhoneNumber}\n" +
                      $"Price Accepted: {lead.PriceAccepted}\n" +
                      $"Lead Description: {lead.Description}\n\n" +
                      $"Thank you for your attention.\n\n" +
                      $"Best regards,\n" +
                      $"Lead Management Team";

        await File.WriteAllTextAsync(fileName, content);

        Debug.WriteLine($"Arquivo {fileName} gerado com sucesso em: {currentDirectory}");
    }
}
