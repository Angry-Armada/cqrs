using Armada.CQRS.Notifications.Contracts.Abstractions;

namespace Armada.CQRS.Notifications.Handlers.Abstractions
{
  public interface INotificationRequestHandler<in TNotification> where TNotification : INotificationRequest
  {
    Task Handle(TNotification notification, CancellationToken cancellationToken = default);
  }
}