using Armada.CQRS.Notifications.Contracts.Abstractions;

namespace Armada.CQRS.Notifications.Middleware.Abstraction
{
  public delegate Task NotificationDelegate(CancellationToken cancellationToken = default);
  
  public interface INotificationMiddleware<in TNotification> where TNotification : INotification
  {
    Task HandleAsync(TNotification notification,
      NotificationDelegate next,
      CancellationToken cancellationToken = default);
  }
}