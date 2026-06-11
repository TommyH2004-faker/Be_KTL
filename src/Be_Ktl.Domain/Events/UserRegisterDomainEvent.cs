using Be_Ktl.Domain.Common;

namespace Be_Ktl.Domain.Events;

public sealed record UserRegisteredDomainEvent(
    Guid UserId,
    string Email
) : DomainEventBase;