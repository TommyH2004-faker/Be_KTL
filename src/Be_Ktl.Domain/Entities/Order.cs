using Be_Ktl.Domain.Common;
using Be_Ktl.Domain.Enums;

namespace Be_Ktl.Domain.Entities;

public class Order : BaseEntity
{
    public string OrderCode { get; private set; } = default!;

    public Guid StudentId { get; private set; }

    public User Student { get; private set; } = default!;

    public Guid? CouponId { get; private set; }

    public Coupon? Coupon { get; private set; }

    public decimal TotalAmount { get; private set; }

    public decimal DiscountAmount { get; private set; }

    public decimal FinalAmount { get; private set; }

    public OrderStatus Status { get; private set; }

    public ICollection<OrderItem> Items { get; } = new List<OrderItem>();

    public Payment? Payment { get; private set; }

    public DateTime OrderedAt { get; private set; }

    public Order() { }

    
}