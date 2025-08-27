using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Notifications.Middleware;

public class WeatherForecastCreatedNotificationLoggingMiddleware(
    ILogger<WeatherForecastCreatedNotificationLoggingMiddleware> logger)
    : INotificationMiddleware<WeatherForecastCreatedNotification>
{
    public Task HandleAsync(WeatherForecastCreatedNotification notification, NotificationDelegate next,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Weather Forecast Created: {Date} / {Temperature}",
            notification.Forecast.Date, notification.Forecast.TemperatureC);

        return next(cancellationToken);
    }
}