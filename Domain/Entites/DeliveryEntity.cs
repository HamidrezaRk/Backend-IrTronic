using Domain.Entites.BaseEntities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class DeliveryEntity : BaseEntity
{
    [ForeignKey(nameof(Order))]
    public required int OrderId { get; set; }
    public OrderEntity? Order { get; set; }
    public DateTime? Date { get; set; }
    public required DriverStatus Status { get; set; }
    public bool ProductHasProblem { get; set; } = false;
    public bool IncompletePayment { get; set; } = false;
    public string? Note { get; set; }
    public decimal? ReceviedMoney { get; set; }
    public DateTime? AcceptedAt { get; set; }
    public double? Distance { get; set; }
}
