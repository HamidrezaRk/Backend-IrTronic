using Domain.Entites.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

 public class InvoiceEntity : BaseEntity
 {
    public string? Comment { get; set; }
    [ForeignKey(nameof(Order))]
    public required int OrderId { get; set; }
    public OrderEntity? Order { get; set; }
}
