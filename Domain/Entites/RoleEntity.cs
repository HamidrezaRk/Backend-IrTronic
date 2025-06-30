using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

public class RoleEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public required string RoleName { get; set; }
    public bool IsChangeable { get; set; }

    [InverseProperty(nameof(RolePermissionEntity.Role))]
    public List<RolePermissionEntity> Permissions { get; set; } = [];
}
