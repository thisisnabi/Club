using Club.BuildingBlocks.Domain;
using System.Net.Mail;

namespace Club.Domain.ProfileAggregate;

public sealed class ProfileId : ValueObject<ProfileId>
{

    public MailAddress Value { get; init; } = null!;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private ProfileId() { }

    public static ProfileId Create(MailAddress mailAddress)
        => new ProfileId { Value = mailAddress };

}