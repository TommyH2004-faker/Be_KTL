using Be_Ktl.Domain.Common;
using Be_Ktl.Domain.Enums;

namespace Be_Ktl.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; private set; }

    public User User { get; private set; } = default!;

    public string Title { get; private set; } = default!;

    public string Content { get; private set; } = default!;

    public bool IsRead { get; private set; }

    public NotificationType Type { get; private set; }

    public DateTime? ReadAt { get; private set; }

    public Notification() { }

    
}