using Domain.Entites;
using Domain.Entites.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

 public class UserRolesEntity : BaseEntity
 {
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }
    public RoleEntity? Role { get; set; }
 }
