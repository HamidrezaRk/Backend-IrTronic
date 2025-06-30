using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

 public class RolePermissionEntity
 {
    [Key]
    public int Id { get; set; }
    public Permission Permission { get; set; }
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    public RoleEntity? Role { get; set; }
}
