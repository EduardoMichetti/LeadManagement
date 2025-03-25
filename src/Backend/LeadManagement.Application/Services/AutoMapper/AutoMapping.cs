using AutoMapper;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;

namespace LeadManagement.Application.Services.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
        DomainToResponse();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterLeadJson, Domain.Entities.LeadEntity>();
    }

    private void DomainToResponse()
    {
        CreateMap<Domain.Entities.LeadEntity, ResponseFilteredLeadJson>();

        CreateMap<Domain.Entities.LeadEntity, ResponseFilteredLeadJson>()
            .ForMember(dest => dest.Id, config => config.MapFrom(src => src.Id));

        CreateMap<Domain.Entities.LeadEntity, ResponseFilteredLeadJson>()
            .ForMember(dest => dest.ContactFirstName, opt => opt.MapFrom(src => src.ContactFirstName))
            .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail));
    }
}
