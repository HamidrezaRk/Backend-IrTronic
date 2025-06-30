using Application.BaseRequest.Interface;
using Application.Results.LoginAndRegister;

namespace Application.Queries.LoginAndRegister
{
   public class AdminLoginRequest()
   {
        public required string Email { get; set; }
        public required string Password { get; set; }
   };
    public class AdminLoginQuery() : BaseRequest<AdminLoginRequest, LoginResult>;
}
