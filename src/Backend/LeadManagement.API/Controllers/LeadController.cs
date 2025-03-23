using LeadManagement.Application.UseCases.Lead.Register;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public class LeadController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredLeadJson) ,StatusCodes.Status201Created)]
    public IActionResult Register(RequestRegisterLeadJson request)
    {
        var useCase = new RegisterLeadUseCase();

        var result = useCase.Execute(request);

        return Created(string.Empty, result);
    }

}
