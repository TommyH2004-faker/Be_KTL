using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid StudentId { get; private set; }

    public User Student { get; private set; } = default!;

    public ICollection<CartItem> Items { get; } = new List<CartItem>();

    public Cart() { }


}