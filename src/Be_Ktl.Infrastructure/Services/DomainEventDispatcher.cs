using Be_Ktl.Application.Common;
using Be_Ktl.Application.Interfaces;
using Be_Ktl.Domain.Common;
using MediatR;

namespace Be_Ktl.Infrastructure.Services;

public sealed class DomainEventDispatcher
    : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchAsync(
        IEnumerable<IDomainEvent> domainEvents,
        CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in domainEvents)
        {
            var notificationType =
                typeof(DomainEventNotification<>)
                    .MakeGenericType(domainEvent.GetType());

            var notification =
                Activator.CreateInstance(
                    notificationType,
                    domainEvent);

            await _mediator.Publish(
                (INotification)notification!,
                cancellationToken);
        }
    }
}