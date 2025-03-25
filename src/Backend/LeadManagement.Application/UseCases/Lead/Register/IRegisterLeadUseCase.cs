using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;

namespace LeadManagement.Application.UseCases.Lead.Register;
public interface IRegisterLeadUseCase
{
    public Task<ResponseRegisteredLeadJson> Execute(RequestRegisterLeadJson request);

    Task Update(long id, RequestUpdateLeadJson request);
}
