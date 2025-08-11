using Armada.CQRS.Notifications.Handlers.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Notifications;

public class SendSmsWeatherForecastCreatedNotificationHandler(
  ILogger<WeatherForecastCreatedNotification> logger) 
  : INotificationHandler<WeatherForecastCreatedNotification>
{
  public Task Handle(WeatherForecastCreatedNotification notification, CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Sending SMS about created forecast: {Date}, {Temp}",
      notification.Forecast.Date, notification.Forecast.TemperatureC);
      
    return Task.CompletedTask;
  }
}