using LeadManagement.Application.UseCases.Lead.Filter;
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
    [ProducesResponseType(typeof(ResponseRegisteredLeadJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterLeadUseCase useCase,
        [FromBody] RequestRegisterLeadJson request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseFilteredLeadJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> FilterStatusID(
    [FromServices] IFilterLeadUseCase useCase,
    [FromRoute] long id)
    {
        var response = await useCase.ExecuteFilterID(id);

        return Ok(response);
    }

    [HttpGet("filterByStatus")]
    [ProducesResponseType(typeof(ResponseListLeadJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> FilterStatus(
    [FromServices] IFilterLeadUseCase useCase,
    [FromQuery] RequestFilterLeadJson request)
    {
        var response = await useCase.ExecuteFilterList(request);

        if (response.LeadsList.Any())
        {
            return Ok(response);
        }
        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
    [FromServices] IRegisterLeadUseCase useCase,
    [FromRoute] long id,
    [FromBody] RequestUpdateLeadJson request)
    {
        await useCase.Update(id, request);

        return NoContent();
    }
}
