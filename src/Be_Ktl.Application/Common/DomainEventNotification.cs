using Be_Ktl.Domain.Common;
using MediatR;

namespace Be_Ktl.Application.Common;

public sealed class DomainEventNotification<TDomainEvent>
    : INotification
    where TDomainEvent : IDomainEvent
{
    public TDomainEvent DomainEvent { get; }

    public DomainEventNotification(
        TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }
}