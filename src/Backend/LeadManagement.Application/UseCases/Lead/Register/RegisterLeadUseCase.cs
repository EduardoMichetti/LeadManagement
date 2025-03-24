using LeadManagement.Application.Services.AutoMapper;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;
using LeadManagement.Exceptions.ExceptionsBase;

namespace LeadManagement.Application.UseCases.Lead.Register;

public class RegisterLeadUseCase
{
    public ResponseRegisteredLeadJson Execute(RequestRegisterLeadJson request)
    {
        Validate(request);

        var autoMapper = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapping());
        }).CreateMapper();

        var user = autoMapper.Map<Domain.Entities.LeadEntity>(request);

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
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

