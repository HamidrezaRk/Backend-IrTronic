using Application.BaseRequest.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static Application.Failures.Failures;

namespace IRTBackend.Controllers.BaseController;

public class BaseController(IMediator mediator) : Controller
{
    protected readonly IMediator mediator = mediator;

    /// <summary>
    /// User ID 
    /// </summary>
    public int? UserID
    {
        get
        {
            var r = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return r is null ? null : Convert.ToInt32(r);
        }
    }

    /// <summary>
    /// Get token expire date
    /// </summary>

    public DateTime? TokenExpireDate
    {
        get
        {

            if (User?.Identity?.IsAuthenticated == true)
            {
                IEnumerable<Claim> claims = User.Claims;
                Claim? expirationClaim = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp);
                if (expirationClaim != null)
                {
                    DateTime expirationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expirationClaim.Value)).UtcDateTime;
                    return expirationTime;
                    // Use expirationTime as needed
                }
            }
            return null;
        }
    }

    public DateTime? TokenCreateDate
    {
        get
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                IEnumerable<Claim> claims = User.Claims;
                Claim? creationClaim = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Iat);
                if (creationClaim != null)
                {
                    DateTime creationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(creationClaim.Value)).UtcDateTime;
                    return creationTime;
                }
            }
            return null;
        }
    }

    public bool IsAuthViaPhone
    {
        get
        {
            var r = User.Claims.FirstOrDefault(x => x.Type == "IsAuthViaPhone");
            return r is not null && bool.Parse(r.Value);
        }
    }

    /// <summary>
    /// Get source IP address
    /// </summary>
    /// <returns></returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    public string GetSourceIpAddress()
    {
        return HttpContext.Connection.RemoteIpAddress?.ToString() ?? "-";
    }

    /// <summary>
    /// Get language from header
    /// </summary>
    /// <returns></returns>

  
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IActionResult> HandleRequest<Body, Result>(BaseRequest<Body, Result> request)
    {
        request.Ip = GetSourceIpAddress();
     //   request.Language = GetLanguageFromHeader();
        request.UserId = UserID;
       // request.TokenIat = TokenCreateDate;
        //request.IsAuthViaPhone = IsAuthViaPhone;
        try
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var handledException = HandleException(ex);
            if (handledException != null)
            {
                return handledException;
            }
            throw;
        }
    }
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult? HandleException(Exception ex)
    {
        if (ex is Failure failure)
        {
            var errorResponse = new
            {
                failure.Code,
                Message = failure.Massage,
                failure.MetaData
            };
            return BadRequest(errorResponse);
        }
        else if (ex is Application.Failures.Failures.AuthorizationFailure)
        {
            return StatusCode(403, (new
            {
                Code = ex is UserIsSuspendedFailure ? 40301 : 40302,
                Message = ex is UserIsSuspendedFailure ? "User is suspended" : "Token is expired"
            }));
        }
        else
        {
            return null;
        }
    }

}
