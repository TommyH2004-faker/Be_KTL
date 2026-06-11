using Be_Ktl.Domain.Common;

namespace Be_Ktl.Application.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(
        IEnumerable<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default);
}