using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

 public class PaymentEntity
 {
    [Key]
    public int Id { get; set; }
    public required string TitleForDelivery { get; set; }
    public string? TitleForPickUp { get; set; }
    public required string AppIconPath { get; set; }
    public required bool IsEnable { get; set; }
    public required PaymentType PaymentType { get; set; }
    public DynamicPaymentType? DynamicPaymentType { get; set; }
    public string? Token { get; set; }
}
