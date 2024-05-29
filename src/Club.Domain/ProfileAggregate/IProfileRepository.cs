using System.Net.Mail;

namespace Club.Domain.ProfileAggregate;
public interface IProfileRepository
{
    Task CreateAsync(Profile profile);
    Task<Profile> FindByIdAsync(ProfileId profileId);
    Task<bool> IsProfileIdUniqueAsync(ProfileId profileId);

    Task SaveChangesAsync();
}
