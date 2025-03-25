using FluentValidation;
using LeadManagement.Communication.Requests;
using LeadManagement.Exceptions;


namespace LeadManagement.Application.UseCases.Lead.Filter;
public class FilterLeadValidatorStatus : AbstractValidator<RequestFilterLeadJson>
{
    public FilterLeadValidatorStatus()
    {
        RuleFor(lead => lead.Status).IsInEnum().WithMessage(ResourceMessagesException.STATUS_NOT_SUPPORTED);
    }
}
