using Application.Queries.LoginAndRegister;
using Application.Results.LoginAndRegister;
using Domain.Enums;
using Domain.IServices;
using MediatR;
using static Application.Failures.Failures;

namespace Application.Handlers.LoginAndRegister;

public class AdminLoginHandler(IUserService UserService,ILoginService loginservice, IPasswordHasherService passwordHasherService) : IRequestHandler<AdminLoginQuery, LoginResult>
{
    private readonly IUserService _userService = UserService;
    private readonly ILoginService loginservice = loginservice;
    private readonly IPasswordHasherService passwordHasherService = passwordHasherService;

    public async Task<LoginResult> Handle(AdminLoginQuery request , CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByEmail(request.RequestBody.Email) ?? throw new EmailOrPasswordIsInvalid();

        if (!user.Roles.Where(x => PermissionConstants.GetAdminRoleIds().Contains(x.RoleId)).Any())
        {
            throw new EmailOrPasswordIsInvalid();
        }

        if (!passwordHasherService.VerifyPassword(request.RequestBody.Password, user.Password!))
        {
            throw new EmailOrPasswordIsInvalid();
        }
        if (user.IsSuspended == true)
        {
            throw new UserSuspendError();
        }

        List<Permission> userPermissions = [];

        foreach (var role in user.Roles)
        {
            foreach (var permission in role.Permissions)
            {
                if (!userPermissions.Contains(permission))
                {
                    userPermissions.Add(permission);
                }
            }

        }
        var Token = loginservice.CreateToken(user.Id, userPermissions, false);
        var userId = user?.Id;
        user!.Password = "";
        return new LoginResult(user, Token);
    }
}
