using Club.Domain.ProfileAggregate;
using MediatR;

namespace Club.Application.Profiles.UpdateBio;
internal class UpdateBioCommandHandler(IProfileRepository profileRepository) : IRequestHandler<UpdateBioCommand>
{
    private readonly IProfileRepository _profileRepository = profileRepository;
    public async Task Handle(UpdateBioCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileRepository.FindByIdAsync(request.ProfileId);

        if (profile is null)
        {
            throw new Exception("Invalid Profile Id.");
        }
 
        profile.UpdateBio(request.Bio);
        await _profileRepository.SaveChangesAsync();
    }
}
