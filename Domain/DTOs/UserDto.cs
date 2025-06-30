using Domain.Enums;

namespace Domain.DTOs;

public class UserNameWithPasswordDTO
{
    public required int Id { get; set; }
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public required string? Email { get; set; }
    public required string? Phone { get; set; }
    public string? Password { get; set; }
    public required bool IsSuspended { get; set; }
    public required string? Username { get; set; }
    public required List<RoleDetailDTO> Roles { get; set; }
    public required List<AddressDTO>? Addresses { get; set; }
    public required Gender? Gender { get; set; }
    public required string CartId { get; set; }
}
