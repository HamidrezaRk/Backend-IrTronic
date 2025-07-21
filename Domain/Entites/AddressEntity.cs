using Domain.Entites.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

 public class AddressEntity 
 {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsPrimary { get; set; }
}
