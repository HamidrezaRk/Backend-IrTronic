using Domain.DTOs;
using Domain.Enums;

namespace Domain.IServices;

public interface IUserService
{
    Task<int> SignUpByEmail(string email, List<Permission> roles);
    Task<int> SignUpByPhone(string countryCode, string phone, List<Permission> roles);
    Task<UserNameWithPasswordDTO?> GetUserByEmail(string email);
}
