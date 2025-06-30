using Domain.Entites;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

 public class UserRolesEntity
 {
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    public RoleEntity? Role { get; set; }
}
