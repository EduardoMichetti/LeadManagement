using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LeadManagement.Communication.Requests;

namespace LeadManagement.Application.UseCases.Lead.Register;
public class RegisterLeadValidator : AbstractValidator<RequestRegisterLeadJson>
{
    public RegisterLeadValidator()
    {
        RuleFor(lead => lead.ContactFirstName).NotEmpty().WithMessage("ContactFirstName is required");
        RuleFor(lead => lead.ContactEmail).NotEmpty().WithMessage("ContactEmail is required");
        RuleFor(lead => lead.ContactEmail).EmailAddress();
    }
}
