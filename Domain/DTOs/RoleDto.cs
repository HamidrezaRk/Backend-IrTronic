using Domain.Enums;

namespace Domain.DTOs;

public class RoleDetailDTO
{
    public required int RoleId { get; set; }
    public required bool IsChangeable { get; set; }
    public required string RoleName { get; set; }
    public required List<Permission> Permissions { get; set; }
}