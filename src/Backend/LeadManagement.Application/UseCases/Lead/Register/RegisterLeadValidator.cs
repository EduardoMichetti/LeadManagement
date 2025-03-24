using FluentValidation;
using LeadManagement.Communication.Requests;
using LeadManagement.Exceptions;

namespace LeadManagement.Application.UseCases.Lead.Register;
public class RegisterLeadValidator : AbstractValidator<RequestRegisterLeadJson>
{
    public RegisterLeadValidator()
    {
        RuleFor(lead => lead.ContactFirstName).NotEmpty().WithMessage(ResourceMessagesException.CONTACT_FIRST_NAME_EMPTY);
        RuleFor(lead => lead.ContactEmail).NotEmpty().WithMessage(ResourceMessagesException.CONTACT_EMAIL_EMPTY);
        RuleFor(lead => lead.ContactEmail).EmailAddress().WithMessage(ResourceMessagesException.CONTACT_EMAIL_INVALID);
    }
}
