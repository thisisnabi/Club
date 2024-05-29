using Club.Domain.ProfileAggregate;
using MediatR;

namespace Club.Application.Clubs;
public record CreateClubCommand(ProfileId ProfileId, string Name) 
    : IRequest<CreateClubCommandResponse>;