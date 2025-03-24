using AutoMapper;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;
using LeadManagement.Domain.Repositories;
using LeadManagement.Domain.Repositories.Lead;
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
        Validate(request);

        //var autoMapper = new AutoMapper.MapperConfiguration(cfg =>
        //{
        //    cfg.AddProfile(new AutoMapping());
        //}).CreateMapper();

        var user = _mapper.Map<Domain.Entities.LeadEntity>(request);

        await _writeOnlyRepository.Add(user);

        await _unitOfWork.Commit();

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

