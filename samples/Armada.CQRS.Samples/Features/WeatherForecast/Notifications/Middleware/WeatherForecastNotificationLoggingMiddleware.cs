using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Notifications.Middleware;

public class WeatherForecastNotificationLoggingMiddleware<TNotification>(
  ILogger<WeatherForecastNotificationLoggingMiddleware<TNotification>> logger) 
  : INotificationMiddleware<TNotification> where TNotification : INotification
{
  public async Task HandleAsync(TNotification notification, NotificationDelegate next,
    CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Weather Forecast Notification Processing: {notification}", typeof(TNotification).Name);
    await next(cancellationToken);
  }
}