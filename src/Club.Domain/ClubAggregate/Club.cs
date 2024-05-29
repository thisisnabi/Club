using Club.BuildingBlocks.Domain;

namespace Club.Domain.ClubAggregate;
public sealed class Club : AggregateRootBase<ClubId>
{



    public Club(ClubId id) : base(id)
    {
    }
}
