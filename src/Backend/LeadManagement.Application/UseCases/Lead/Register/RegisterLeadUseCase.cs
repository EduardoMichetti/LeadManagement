using AutoMapper;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;
using LeadManagement.Domain.Repositories;
using LeadManagement.Domain.Repositories.Lead;
using LeadManagement.Exceptions;
using LeadManagement.Exceptions.ExceptionsBase;

namespace LeadManagement.Application.UseCases.Lead.Register;

public class RegisterLeadUseCase : IRegisterLeadUseCase
{
    private readonly ILeadWriteOnlyRepository _writeOnlyRepository;
    private readonly ILeadReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterLeadUseCase(
        ILeadWriteOnlyRepository writeOnlyRepository,
        ILeadReadOnlyRepository readOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisteredLeadJson> Execute(RequestRegisterLeadJson request)
    {
        await Validate(request);

        var lead = _mapper.Map<Domain.Entities.LeadEntity>(request);

        await _writeOnlyRepository.Add(lead);

        await _unitOfWork.Commit();

        return new ResponseRegisteredLeadJson
        {
            ContactFirstName = request.ContactFirstName
        };
    }

    private async Task Validate(RequestRegisterLeadJson request)
    {
        var validator = new RegisterLeadValidator();

        var result = validator.Validate(request);

        var emailExist = await _readOnlyRepository.ExistActiveLeadWithEmail(request.ContactEmail);
        if (emailExist)
        {
            result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.CONTACT_EMAIL_REGISTERED));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

