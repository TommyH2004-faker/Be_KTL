namespace Be_Ktl.Domain.Common;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}