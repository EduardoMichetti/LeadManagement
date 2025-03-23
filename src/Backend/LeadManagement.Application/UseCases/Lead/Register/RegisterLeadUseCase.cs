using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;

namespace LeadManagement.Application.UseCases.Lead.Register;

public class RegisterLeadUseCase
{
    public ResponseRegisteredLeadJson Execute(RequestRegisterLeadJson request)
    {
        Validate(request);

        //todo: mapear a request para a entidade

        //todo: Salvar a entidade

        return new ResponseRegisteredLeadJson
        {
            ContactFirstName = request.ContactFirstName
        };
    }

    private void Validate(RequestRegisterLeadJson request)
    {
        var validator = new RegisterLeadValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage);
            throw new Exception("Invalid request");
        }
    }
}

