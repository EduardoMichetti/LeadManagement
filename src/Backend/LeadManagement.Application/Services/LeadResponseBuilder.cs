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
            ContactFullName = status == LeadStatus.Approved ? r.ContactFullName : null,
            ContactPhoneNumber = status == LeadStatus.Approved ? r.ContactPhoneNumber : null,
            ContactEmail = status == LeadStatus.Approved ? r.ContactEmail : null,
            r.Suburb,
            r.Category,
            r.Description,
            Price = status == LeadStatus.Pending ? r.Price : (decimal?)null,
            PriceAccepted = status == LeadStatus.Approved ? r.PriceAccepted : (decimal?)null
        }).ToList();
    }
}