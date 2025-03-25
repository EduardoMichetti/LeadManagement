using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;

namespace LeadManagement.Application.UseCases.Lead.Filter;
public interface IFilterLeadUseCase
{
    Task<ResponseFilteredLeadJson> ExecuteFilterID(long id);

    Task<ResponseListLeadJson> ExecuteFilterList(RequestFilterLeadJson request);

}
