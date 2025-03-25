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

    [HttpPost("filter")]
    [ProducesResponseType(typeof(ResponseFilteredLeadJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> FilterStatusCode(
    [FromServices] IRegisterLeadUseCase useCase,
    [FromBody] RequestFilterLeadJson request)
    {
        var response = await useCase.ExecuteFilter(request);

        if (response.ContactEmail != null && response.ContactEmail.Length != 0)
        {
            return Ok(response);
        }
        return NoContent();

    }

}
