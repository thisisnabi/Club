using Club.BuildingBlocks.Domain;
using Club.Domain.ProfileAggregate;

namespace Club.Domain.ClubAggregate;
public sealed class Club : AggregateRootBase<ClubId>
{
    public ProfileId ProfileId { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public DateTime Createdon { get; private set; }

    private Club(ClubId id) : base(id)
    {

    }

    public static Club Create(string name, ProfileId profileId)
    {
        return new Club(ClubId.CreateUniqueId())
        {
            ProfileId = profileId,
            Name = name,
            Createdon = DateTime.UtcNow
        };
    }
}
