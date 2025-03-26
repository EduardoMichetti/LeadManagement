using System.Data;
using AutoMapper;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Repositories;
using LeadManagement.Domain.Repositories.Lead;
using LeadManagement.Domain.Services;
using LeadManagement.Exceptions;
using LeadManagement.Exceptions.ExceptionsBase;

namespace LeadManagement.Application.UseCases.Lead.Register;

public class RegisterLeadUseCase : IRegisterLeadUseCase
{
    private readonly ILeadWriteOnlyRepository _writeOnlyRepository;
    private readonly ILeadReadOnlyRepository _readOnlyRepository;
    private readonly ILeadUpdateOnlyRepository _updateOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileGenerationService _fileGenerationService;

    private const double LEAD_DISCOUNT_PERCENTAGE = 0.9;
    private const double LEAD_BASE_DISCOUNT_VALUE = 500;

    public RegisterLeadUseCase(
        ILeadWriteOnlyRepository writeOnlyRepository,
        ILeadReadOnlyRepository readOnlyRepository,
        ILeadUpdateOnlyRepository updateOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IFileGenerationService fileGenerationService)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _updateOnlyRepository = updateOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _fileGenerationService = fileGenerationService;
    }

    public async Task<ResponseRegisteredLeadJson> Execute(RequestRegisterLeadJson request)
    {
        await Validate(request);

        var lead = _mapper.Map<Domain.Entities.LeadEntity>(request);

        await _writeOnlyRepository.Add(lead);

        await _unitOfWork.Commit();

        return new ResponseRegisteredLeadJson
        {
            Id = lead.Id,
            ContactFirstName = request.ContactFirstName
        };
    }

    public async Task Update(long id, RequestUpdateLeadJson request)
    {
        ValidateUpdate(request);

        var lead = await _updateOnlyRepository.GetById(id) ??
            throw new NotFoundException(ResourceMessagesException.ERROR_NOT_FOUND);

        await UpdateLeadStatus(lead, request);

        _updateOnlyRepository.Update(lead);

        await _unitOfWork.Commit();
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

    private static void ValidateUpdate(RequestUpdateLeadJson request)
    {
        var validator = new RegisterLeadValidatorUpdate();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    private async Task UpdateLeadStatus(LeadEntity lead, RequestUpdateLeadJson request)
    {
        lead.Status = request.Status;
        if (lead.Status == LeadStatus.Accept)
        {
            lead.PriceAccepted = lead.Price >= LEAD_BASE_DISCOUNT_VALUE ? lead.Price * LEAD_DISCOUNT_PERCENTAGE : lead.Price;
            await _fileGenerationService.GenerateFileAsync(lead);
        }
    }
}

