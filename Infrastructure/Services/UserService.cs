using Domain.DTOs;
using Domain.Enums;
using Domain.IServices;
using Infrastructure.DbContext;
using System.Data.Entity;

namespace Infrastructure.Services;

public class UserService(MasterDbContext MasterContext, SlaveDbContext SlaveContext) : IUserService
{
    private readonly MasterDbContext MasterContext = MasterContext;
    private readonly SlaveDbContext SlaveContext = SlaveContext;
    public async Task<UserNameWithPasswordDTO?> GetUserByEmail(string email)
    {
        //List<AddressDTO> Addresses = [];
        //var result = await SlaveContext.Users
        //      .Include(x => x.Roles)!
        //      .ThenInclude(x => x.Role)
        //      .Include(x => x.Addresses)
        //      .Where(x => x.Email == email)
        //      .Select(x => new UserNameWithPasswordDTO
        //      {
        //          Id = x.Id,
        //          Password = x.HashedPassword,
        //          FirstName = x.FirstName,
        //          LastName = x.LastName,
        //          Phone = x.Phone,
        //          Email = x.Email!,
        //          Roles = x.Roles!.Select(x => new RoleDetailDTO()
        //          {
        //              IsChangeable = x.Role!.IsChangeable,
        //              Permissions = x.Role.Permissions!.Select(x => x.Permission).ToList(),
        //              RoleId = x.RoleId,
        //              RoleName = x.Role.RoleName
        //          }).ToList(),
        //          IsSuspended = x.IsSuspended,
        //          Gender = x.Gender,
        //          Username = x.Username,
        //          Addresses = x.Addresses == null ? Addresses : x.Addresses.Select(
        //              s => new AddressDTO
        //              {
        //                  Id = s.Id,
        //                  FirstName = s.FirstName,
        //                  LastName = s.LastName,
        //                  PhoneNumber = s.PhoneNumber,
        //                  ZoneId = s.ZoneId
        //              }).ToList(),
        //          CartId = x.CartId,
        //      }).FirstOrDefaultAsync();
        //return  result;
                throw new NotImplementedException();

    }

    public Task<int> SignUpByEmail(string email, List<Permission> roles)
    {
        throw new NotImplementedException();
    }

    public Task<int> SignUpByPhone(string countryCode, string phone, List<Permission> roles)
    {
        throw new NotImplementedException();
    }
}
