using Club.Domain.ProfileAggregate;
using MediatR;

namespace Club.Application.Profiles.ClubCreated;
internal class ClubCreatedEventHandler : INotificationHandler<ClubCreatedEvent>
{
    public Task Handle(ClubCreatedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
