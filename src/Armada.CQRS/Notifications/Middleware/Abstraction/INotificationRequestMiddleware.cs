using Armada.CQRS.Notifications.Contracts.Abstractions;

namespace Armada.CQRS.Notifications.Middleware.Abstraction
{
  public delegate Task NotificationRequestDelegate(CancellationToken cancellationToken = default);
  
  public interface INotificationRequestMiddleware<in TNotification> where TNotification : INotificationRequest
  {
    Task HandleAsync(TNotification notification,
      NotificationRequestDelegate next,
      CancellationToken cancellationToken = default);
  }
}