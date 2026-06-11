using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid CartId { get; private set; }

    public Cart Cart { get; private set; } = default!;

    public Guid CourseId { get; private set; }

    public Course Course { get; private set; } = default!;

    public decimal Price { get; private set; }

    public int Quantity { get; private set; } = 1;

    public CartItem() { }

   
}