using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LeadManagement.Communication.Requests;
using LeadManagement.Exceptions;

namespace LeadManagement.Application.UseCases.Lead.Register;
public class RegisterLeadValidator : AbstractValidator<RequestRegisterLeadJson>
{
    public RegisterLeadValidator()
    {
        RuleFor(lead => lead.ContactFirstName).NotEmpty().WithMessage(ResourceMessagesException.CONTACT_FIRST_NAME);
        RuleFor(lead => lead.ContactEmail).NotEmpty().WithMessage("ContactEmail is required");
        RuleFor(lead => lead.ContactEmail).EmailAddress();
    }
}
