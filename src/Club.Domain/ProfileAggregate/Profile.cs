using Club.BuildingBlocks.Domain;
using Club.Domain.ClubAggregate;

namespace Club.Domain.ProfileAggregate;

public sealed class Profile : AggregateRootBase<ProfileId>
{
    public string Name { get; private set; } = null!;

    public string? Bio { get; private set; }

    private readonly List<Social> _socials;
    public IReadOnlyCollection<Social> Socials => [.. _socials];

    private readonly List<ClubId> _clubIds;
    public IReadOnlyCollection<ClubId> clubIds => [.. _clubIds];

    public bool IsPublic { get; private set; }

    private Profile(ProfileId id) : base(id)
    {
        _socials = [];
        _clubIds = [];
    }

    public bool CanInvite() => IsPublic;

    public static Profile Create(string name, ProfileId profileId)
    {
        return new Profile(profileId)
        {
            Name = name,
            IsPublic = false
        };
    }

    public void UpdateBio(string bio)
    {
        if (bio.Length > 500)
            throw new Exception("What are you doing baby!");

        Bio = bio;
    }

    public void AddSocial(Social social)
    {
        if (_socials.Any(x => x == social))
            throw new Exception("What are you doing baby!");

        _socials.Add(social);
    }

    public void RaiseClubCreatedEvent(ClubId clubId) =>
        AddEvent(new ClubCreatedEvent(Id, clubId));
}
