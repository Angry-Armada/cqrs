using Armada.CQRS.Notifications.Contracts.Abstractions;

namespace Armada.CQRS.Notifications.Handlers.Abstractions
{
  public interface INotificationHandler<in TNotification> where TNotification : INotification
  {
    Task Handle(TNotification notification, CancellationToken cancellationToken = default);
  }
}