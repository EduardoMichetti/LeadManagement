using LeadManagement.Communication.Responses;
using LeadManagement.Domain.Enums;

namespace LeadManagement.Application.Services;
public class LeadResponseBuilder
{
    public List<object> BuildResponse(List<ResponseFilteredLeadJson> leads, LeadStatus status)
    {
        return leads.Select(r => (object)new
        {
            r.Id,
            r.CreatedDate,
            ContactFirstName = status == LeadStatus.Pending ? r.ContactFirstName : null,
            ContactFullName = status == LeadStatus.Accept ? r.ContactFullName : null,
            ContactPhoneNumber = status == LeadStatus.Accept ? r.ContactPhoneNumber : null,
            ContactEmail = status == LeadStatus.Accept ? r.ContactEmail : null,
            r.Suburb,
            r.Category,
            r.Description,
            Price = status == LeadStatus.Pending ? r.Price : (decimal?)null,
            PriceAccepted = status == LeadStatus.Accept ? r.PriceAccepted : (decimal?)null
        }).ToList();
    }
}