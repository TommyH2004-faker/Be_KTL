using Be_Ktl.Domain.Common;

using Be_Ktl.Domain.Enums;

namespace Be_Ktl.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid OrderId { get; private set; }

    public Order Order { get; private set; } = default!;

    public string TransactionCode { get; private set; } = default!;

    public decimal Amount { get; private set; }

    public PaymentGateway Gateway { get; private set; }

    public PaymentStatus Status { get; private set; }

    public DateTime? PaidAt { get; private set; }

    public Payment() { }

    
}