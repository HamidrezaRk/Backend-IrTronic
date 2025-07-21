using Domain.Entites.BaseEntities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

 public class OrderCommentEntity : BaseEntity
 {
    public required string Comment { get; set; }
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; }
    public OrderStatus OrderStatus { get; set; }
}
