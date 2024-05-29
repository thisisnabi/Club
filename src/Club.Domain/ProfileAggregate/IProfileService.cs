namespace Club.Domain.ProfileAggregate;
public interface IProfileService
{
    Task<bool> CanAddClubAsync(ProfileId profileId);
    Task<Profile> GetProfileByIdAsync(ProfileId profileId);
}
