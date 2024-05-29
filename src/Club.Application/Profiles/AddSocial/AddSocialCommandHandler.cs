using Club.Domain.ProfileAggregate;
using MediatR;

namespace Club.Application.Profiles.AddSocial;
public sealed class AddSocialCommandHandler(IProfileRepository profileRepository) : IRequestHandler<AddSocialCommand>
{
    private readonly IProfileRepository _profileRepository = profileRepository;
    public async Task Handle(AddSocialCommand request, CancellationToken cancellationToken)
    {
        var profile = await _profileRepository.FindByIdAsync(request.ProfileId);

        if (profile is null)
        {
            throw new Exception("Invalid Profile Id.");
        }

        profile.AddSocial(request.Social);
        await _profileRepository.SaveChangesAsync();

    }
}