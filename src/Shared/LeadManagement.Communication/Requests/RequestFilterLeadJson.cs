using LeadManagement.Domain.Enums;
namespace LeadManagement.Communication.Requests;

public class RequestFilterLeadJson
{
    public LeadStatus Status { get; set; }
}
