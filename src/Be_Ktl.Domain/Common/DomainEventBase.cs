namespace Be_Ktl.Domain.Common;

public abstract record DomainEventBase : IDomainEvent
{
    public DateTime OccurredOn { get; init; }
        = DateTime.UtcNow;
}