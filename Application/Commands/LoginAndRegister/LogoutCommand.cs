using Application.BaseRequest.Interface;
using Application.Results;

namespace Application.Commands.LoginAndRegister;

 public class LogoutRequest
 {
    public required string DeviceId { get; set; }
 }
public class LogoutCommand :BaseRequest<LogoutRequest ,SuccessfulResult>;
