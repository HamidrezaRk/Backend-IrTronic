using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRTBackend.Controllers;

[Route("")]
[ApiController]
public class TermsAndConditionsController(IMediator mediator) : BaseController(mediator)
{
}

