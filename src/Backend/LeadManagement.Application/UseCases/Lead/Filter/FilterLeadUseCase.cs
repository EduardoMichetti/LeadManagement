using System.Data;
using AutoMapper;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;
using LeadManagement.Domain.Repositories;
using LeadManagement.Domain.Repositories.Lead;
using LeadManagement.Exceptions.ExceptionsBase;

namespace LeadManagement.Application.UseCases.Lead.Filter;
public class FilterLeadUseCase : IFilterLeadUseCase
{
    private readonly ILeadWriteOnlyRepository _writeOnlyRepository;
    private readonly ILeadReadOnlyRepository _readOnlyRepository;
    private readonly ILeadUpdateOnlyRepository _updateOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FilterLeadUseCase(
    ILeadWriteOnlyRepository writeOnlyRepository,
    ILeadReadOnlyRepository readOnlyRepository,
    ILeadUpdateOnlyRepository updateOnlyRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _updateOnlyRepository = updateOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseFilteredLeadJson> ExecuteFilterID(long id)
    {

        var lead = await _updateOnlyRepository.GetById(id);

        if (lead is null)
        {
            throw new DataException("Lead not found");
        }

        return _mapper.Map<ResponseFilteredLeadJson>(lead);
    }

    public async Task<ResponseFilteredLeadJson> ExecuteFilter(RequestFilterLeadJson request)
    {
        Validate(request);

        var leads = await _readOnlyRepository.GetLeadByStatus(request.Status);

        return _mapper.Map<ResponseFilteredLeadJson>(leads);
        //return new ResponseFilteredLeadJson
        //{
        //    //TODO: FAZER MAPPER
        //    ContactFirstName = leads?.ContactFirstName,
        //    ContactEmail = leads?.ContactEmail,
        //};
    }

    public async Task<ResponseListLeadJson> ExecuteFilterList(RequestFilterLeadJson request)
    {
        Validate(request);

        //var leads = await _readOnlyRepository.GetLeadByStatus(request.Status);

        var filters = new Domain.Dto.FilterLeadsDto
        {
            Status = request.Status
        };

        var leadsList = await _readOnlyRepository.FilterList(filters);

        return new ResponseListLeadJson
        {
            LeadsList = _mapper.Map<List<ResponseFilteredLeadJson>>(leadsList)
        };
    }

    private static void Validate(RequestFilterLeadJson request)
    {
        var validator = new FilterLeadValidatorStatus();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }



}
