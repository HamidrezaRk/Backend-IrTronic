using Application.Queries.LoginAndRegister;
using Application.Results;
using Application.Results.LoginAndRegister;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IRTBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginAndSignUpController(IMediator mediator) : BaseController.BaseController(mediator)
    {
        [HttpPost("AdminLoginWithEmailAndPassword")]
        [ProducesResponseType(typeof(LoginResult), 200)]
        [ProducesResponseType(typeof(AppBadRequestResult), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AdminLoginWithEmailAndPassword([FromBody] AdminLoginRequest request) => await HandleRequest(new AdminLoginQuery()
        {
            RequestBody = request
        });
    }
}
