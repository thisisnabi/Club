using Club.BuildingBlocks.Domain;

namespace Club.Domain.ClubAggregate;

public sealed class ClubId : ValueObject<ClubId>
{
    public Guid Value { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private ClubId() { }

    public static ClubId Create(Guid id)
        => new ClubId { Value = id, };

    public static ClubId CreateUniqueId()
        => new ClubId { Value = Guid.NewGuid() };

}