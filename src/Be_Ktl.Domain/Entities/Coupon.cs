using Be_Ktl.Domain.Common;

using Be_Ktl.Domain.Enums;

namespace Be_Ktl.Domain.Entities;

public class Coupon : BaseEntity
{
    public string Code { get; private set; } = default!;

    public string? Description { get; private set; }

    public CouponType Type { get; private set; }

    public decimal Value { get; private set; }

    public decimal? MinimumOrderAmount { get; private set; }

    public int? MaxUsageCount { get; private set; }

    public int UsedCount { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public Coupon() { }

   
}