using FluentValidation;
using LeadManagement.Communication.Requests;
using LeadManagement.Domain.Enums;
using LeadManagement.Exceptions;

namespace LeadManagement.Application.UseCases.Lead.Register;
public class RegisterLeadValidatorUpdate : AbstractValidator<RequestUpdateLeadJson>
{
    public RegisterLeadValidatorUpdate()
    {
        RuleFor(lead => lead.Status)
            .IsInEnum()
            .WithMessage(ResourceMessagesException.STATUS_NOT_SUPPORTED);

        RuleFor(lead => lead.Status)
            .Must(status => status == LeadStatus.Accept || status == LeadStatus.Decline)
            .WithMessage(ResourceMessagesException.STATUS_NOT_ACCEPTABLE)
            .When(lead => Enum.IsDefined(typeof(LeadStatus), lead.Status));
    }
}