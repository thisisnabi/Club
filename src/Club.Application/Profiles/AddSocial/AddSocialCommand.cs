using Club.Domain.ProfileAggregate;
using MediatR;

namespace Club.Application.Profiles.AddSocial;
public record AddSocialCommand(ProfileId ProfileId, Social Social) : IRequest;