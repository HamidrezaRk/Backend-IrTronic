using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
    /// <summary>
    /// Get source IP address
    /// </summary>
    /// <returns></returns>
    [ApiExplorerSettings(IgnoreApi = true)]
    public string GetSourceIpAddress()
    {
        return HttpContext.Connection.RemoteIpAddress?.ToString() ?? "-";
    }

}
