using Application.Queries.TermsAndConditions;
using Application.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRTBackend.Controllers;

[Route("")]
[ApiController]
public class TermsAndConditionsController(IMediator mediator) : BaseController.BaseController(mediator)
{
    [HttpGet("/TermsAndConditions")]
    [ProducesResponseType(typeof(SuccessfulResult), 200)]
    [ProducesResponseType(typeof(AppBadRequestResult), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetTermsAndConditions([FromQuery] GetTermsAndConditionsRequest request)
    {
        return await HandleRequest(new GetTermsAndConditionsQuery() { RequestBody = request });
    }
}

