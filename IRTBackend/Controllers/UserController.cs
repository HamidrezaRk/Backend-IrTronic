using Application.Commands.LoginAndRegister;
using Application.Results;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IRTBackend.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController(IMediator mediator) : BaseController.BaseController(mediator)
    {
        [HttpDelete("/Users/LogoutAdmin")]
        [ProducesResponseType(typeof(SuccessfulResult), 200)]
        [ProducesResponseType(typeof(AppBadRequestResult), 400)]
        [ProducesResponseType(500)]
        [Authorize(Roles = $"{PermissionConstants.AdminId},{PermissionConstants.ShopAdminId},{PermissionConstants.DispatcherId},{PermissionConstants.OperatorId},{PermissionConstants.ContentManagementId},{PermissionConstants.FinanceId}")]
        public async Task<IActionResult> LogoutAdmin([FromQuery] LogoutRequest request)
        {
            return await HandleRequest(new LogoutCommand() { RequestBody = request });
        }
    }
}
