using AutoMapper;
using LeadManagement.Communication.Requests;

namespace LeadManagement.Application.Services.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterLeadJson, Domain.Entities.LeadEntity>();
    }
}
