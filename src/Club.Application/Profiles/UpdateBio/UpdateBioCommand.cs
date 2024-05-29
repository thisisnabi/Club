using Club.Domain.ProfileAggregate;
using MediatR;

namespace Club.Application.Profiles.UpdateBio;
public record UpdateBioCommand(ProfileId ProfileId, string Bio) : IRequest;