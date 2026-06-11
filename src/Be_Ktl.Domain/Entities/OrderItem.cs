using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; private set; }

    public Order Order { get; private set; } = default!;

    public Guid CourseId { get; private set; }

    public Course Course { get; private set; } = default!;

    public decimal Price { get; private set; }

    public decimal? OriginalPrice { get; private set; }

    public OrderItem() { }

   
}