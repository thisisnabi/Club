using Club.Domain.ProfileAggregate;
using MediatR;

namespace Club.Application.Profiles.CreateProfile;

public sealed class CreateProfileCommandHandler(IProfileRepository profileRepository) 
    : IRequestHandler<CreateProfileCommand, CreateProfileCommandResponse>
{
    private readonly IProfileRepository _profileRepository = profileRepository;

    public async Task<CreateProfileCommandResponse> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var profileId = ProfileId.Create(request.MailAddress);
        if (await _profileRepository.IsProfileIdUniqueAsync(profileId))
        {
            throw new Exception("Your email address already exist!");
        }

        var profile = Profile.Create(request.Name, profileId);
        
        await _profileRepository.CreateAsync(profile);
        await _profileRepository.SaveChangesAsync();

        return new CreateProfileCommandResponse(profile.Id);
    }
}
