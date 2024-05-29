namespace Club.BuildingBlocks.Domain;

public interface IDomainEvent
{
    public Guid EventId { get; }

    DateTime OccurredOn { get; }
}