using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;

namespace LeadManagement.Application.UseCases.Lead.Filter;
public interface IFilterLeadUseCase
{
    public Task<ResponseFilteredLeadJson> ExecuteFilter(RequestFilterLeadJson request);

    Task<ResponseFilteredLeadJson> ExecuteFilterID(long id);

    Task<ResponseListLeadJson> ExecuteFilterList(RequestFilterLeadJson request);

    //public IList<ResponseListLeadJson> ExecuteFilterList(RequestFilterLeadJson request);
}
