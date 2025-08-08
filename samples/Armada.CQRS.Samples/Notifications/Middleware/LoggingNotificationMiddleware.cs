using System.Threading;
using System.Threading.Tasks;
using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Middleware.Abstraction;
using Microsoft.Extensions.Logging;

namespace Armada.CQRS.Samples.Notifications.Middleware
{
  public class LoggingNotificationMiddleware<TNotification>(
    ILogger<LoggingNotificationMiddleware<TNotification>> logger) 
    : INotificationRequestMiddleware<TNotification> where TNotification : INotificationRequest
  {
    public async Task HandleAsync(TNotification notification, NotificationRequestDelegate next,
      CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Notification processing: {command}", typeof(TNotification).Name);
      await next(cancellationToken);
    }
  }
}