using Domain.Enums;

namespace Domain.IServices;

public interface ILoginService
{
    public string CreateToken(int UserId, List<Permission> roles, bool authViaPhone);

}
