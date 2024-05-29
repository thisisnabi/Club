using Club.Application.Profiles.CreateProfile;
using Club.Domain.ClubAggregate;
using Club.Domain.ProfileAggregate;
using MediatR;

namespace Club.Application.Clubs;
internal class CreateClubCommandHandler(
    IProfileService profileService,
    IClubRepositpry clubRepositpry)
    : IRequestHandler<CreateClubCommand, CreateClubCommandResponse>
{
    private readonly IClubRepositpry _clubRepositpry = clubRepositpry;
    private readonly IProfileService _profileService = profileService;

    public async Task<CreateClubCommandResponse> Handle(CreateClubCommand request, CancellationToken cancellationToken)
    {
        if (await _profileService.CanAddClubAsync(request.ProfileId))
        {
            throw new Exception("you can't add club to the profile");
        }

        var profile = await _profileService.GetProfileByIdAsync(request.ProfileId);
        var club = Domain.ClubAggregate.Club.Create(request.Name, request.ProfileId);

        profile.RaiseClubCreatedEvent(club.Id);

        await _clubRepositpry.CreateAsync(club);
        await _clubRepositpry.SaveChangesAsync();
         
        return new CreateClubCommandResponse(club.Id);
    }
}
