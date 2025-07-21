using Domain.Entites.BaseEntities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class OrderLogEntity : BaseEntity
{
    public OrderLogs Log { get; set; }
    public required string Message { get; set; }
    public OrderEntity? Order { get; set; }
    [ForeignKey(nameof(Order))]
    public int OrderId { get; set; }
}
