using Be_Ktl.Application.Common;
using Be_Ktl.Domain.Events;
using MediatR;

namespace Be_Ktl.Application.EventHandlers;

public sealed class UserRegisteredHandler
    : INotificationHandler<
        DomainEventNotification<UserRegisteredDomainEvent>>
{
    public async Task Handle(
        DomainEventNotification<UserRegisteredDomainEvent> notification,
        CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        Console.WriteLine(
            $"User Registered: {domainEvent.Email}");

        await Task.CompletedTask;
    }
}