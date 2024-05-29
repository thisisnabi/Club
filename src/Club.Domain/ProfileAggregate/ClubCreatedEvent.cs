using Club.BuildingBlocks.Domain;
using Club.Domain.ClubAggregate;

namespace Club.Domain.ProfileAggregate;
public record ClubCreatedEvent(ProfileId ProfileId,ClubId ClubId) : IDomainEvent
{

    public Guid EventId => Guid.NewGuid();

    public DateTime OccurredOn => DateTime.UtcNow;
}
