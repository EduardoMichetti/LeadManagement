using LeadManagement.Application.Services.AutoMapper;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;
using LeadManagement.Domain.Repositories.Lead;
using LeadManagement.Exceptions.ExceptionsBase;

namespace LeadManagement.Application.UseCases.Lead.Register;

public class RegisterLeadUseCase
{
    private readonly ILeadWriteOnlyRepository _writeOnlyRepository;
    private readonly ILeadReadOnlyRepository _readOnlyRepository;

    public async Task<ResponseRegisteredLeadJson> Execute(RequestRegisterLeadJson request)
    {
        Validate(request);

        var autoMapper = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapping());
        }).CreateMapper();

        var user = autoMapper.Map<Domain.Entities.LeadEntity>(request);

        await _writeOnlyRepository.Add(user);

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

