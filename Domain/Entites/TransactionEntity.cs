using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class TransactionEntity
{
    public int Id { get; }
    public required TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    [ForeignKey(nameof(Payment))]
    public int? PaymentId { get; set; }
    public PaymentEntity? Payment { get; set; }
    public string? Comment { get; set; }
    public string? PgwTransactionId { get; set; }
    [ForeignKey(nameof(Order))]
    public int? OrderId { get; set; }
    public OrderEntity? Order { get; set; }
}

public enum TransactionType
{
    Withdraw,
    Deposit,
}

