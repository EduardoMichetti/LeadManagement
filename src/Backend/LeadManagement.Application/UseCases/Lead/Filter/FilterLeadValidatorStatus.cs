using FluentValidation;
using LeadManagement.Communication.Requests;


namespace LeadManagement.Application.UseCases.Lead.Filter;
public class FilterLeadValidatorStatus : AbstractValidator<RequestFilterLeadJson>
{
    public FilterLeadValidatorStatus()
    {
        //TODO: VERIFICAR FALHA AO CHAMAR CONSTANTE
        RuleFor(lead => lead.Status).IsInEnum().WithMessage("ResourceMessagesException.STATUS_EMPTY");
    }
}
