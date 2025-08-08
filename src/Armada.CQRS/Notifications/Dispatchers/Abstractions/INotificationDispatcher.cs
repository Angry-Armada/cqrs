using Armada.CQRS.Notifications.Contracts.Abstractions;

namespace Armada.CQRS.Notifications.Dispatchers.Abstractions
{
  public interface INotificationDispatcher
  {
    Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
      where TNotification: INotification;
  }
}