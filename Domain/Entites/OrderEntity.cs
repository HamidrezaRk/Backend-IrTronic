using Domain.Entites.BaseEntities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

public class OrderEntity : BaseEntity
{
    public required OrderStatus Status { get; set; }
    [Range(0, 23)]
    public int DeliveryTimeHours { get; set; }
    [InverseProperty(nameof(OrderLogEntity.Order))]
    public List<OrderLogEntity> Logs { get; set; } = [];
    public required DateOnly DeliveryDateOnly { get; set; }
    public required decimal Price { get; set; }
    public required OrderDeliveyType DeliveryType { get; set; }
    public required decimal Total { get; set; }
    [ForeignKey(nameof(PickupLocation))]
    public int? PickupLocationId { get; set; }
    [ForeignKey(nameof(OrderLocation))]
    public int? OrderLocationId { get; set; }
    public UserEntity? PickupLocation { get; set; }
    public UserEntity? OrderLocation { get; set; }
    public bool IsArchived { get; set; } = false;
    [ForeignKey(nameof(Address))]
    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    [InverseProperty(nameof(DeliveryEntity.Order))]
    public List<DeliveryEntity> Deliveries { get; set; } = [];
    public string? CancelReason { get; set; }
    public bool IsGift { get; set; } = false;
    [ForeignKey(nameof(Payment))]
    public int? PaymentId { get; set; }
    public PaymentEntity? Payment { get; set; }
    public DeliveryTypeWithPickup DeliveryZoneType { get; set; }
    [InverseProperty(nameof(InvoiceEntity.Order))]
    public List<InvoiceEntity> Invoices { get; set; } = [];
    [InverseProperty(nameof(OrderCommentEntity.Order))]
    public List<OrderCommentEntity>? Comments { get; set; }
    public decimal? PaidFromWallet { get; set; }
    public decimal? ShippingFee { get; set; }
}
