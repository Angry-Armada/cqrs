using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Samples.Notifications.Middleware
{
  public class LoggingNotificationMiddleware<TNotification>(
    ILogger<LoggingNotificationMiddleware<TNotification>> logger) 
    : INotificationMiddleware<TNotification> where TNotification : INotification
  {
    public async Task HandleAsync(TNotification notification, NotificationDelegate next,
      CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Notification processing: {command}", typeof(TNotification).Name);
      await next(cancellationToken);
    }
  }
}