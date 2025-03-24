using LeadManagement.Application.UseCases.Lead.Register;
using LeadManagement.Communication.Requests;
using LeadManagement.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers;

[Route("[controller]")]
[ApiController]
public class LeadController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredLeadJson) ,StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterLeadUseCase useCase,
        [FromBody] RequestRegisterLeadJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }

}
