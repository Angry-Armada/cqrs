using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Samples.Notifications.Middleware;

public class GlobalNotificationLoggingMiddleware<TNotification>(
    ILogger<GlobalNotificationLoggingMiddleware<TNotification>> logger) 
    : INotificationMiddleware<TNotification> where TNotification : INotification
{
    public async Task HandleAsync(TNotification notification, NotificationDelegate next,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Notification Processing: {notification}", typeof(TNotification).Name);
        await next(cancellationToken);
    }
}