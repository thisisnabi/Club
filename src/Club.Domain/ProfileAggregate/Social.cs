using Club.BuildingBlocks.Domain;
using System.Net.Mail;

namespace Club.Domain.ProfileAggregate;

public sealed class Social : ValueObject<Social>
{
    public required SocialKind Kind { get; init; }
    public required string Url { get; init; }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Kind;
        yield return Url;
    }

    public static Social Create(SocialKind kind, string url)
    => new Social
    {
        Kind = kind,
        Url = url
    };
}