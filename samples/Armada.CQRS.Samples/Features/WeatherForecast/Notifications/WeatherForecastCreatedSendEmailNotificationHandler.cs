using Armada.CQRS.Notifications.Handlers.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Notifications;

public class WeatherForecastCreatedSendEmailNotificationHandler(
  ILogger<WeatherForecastCreatedSendEmailNotificationHandler> logger) 
  : INotificationHandler<WeatherForecastCreatedNotification>
{
  public Task Handle(WeatherForecastCreatedNotification notification, CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Sending email about created forecast: {Date}, {Temp}",
      notification.Forecast.Date, notification.Forecast.TemperatureC);
      
    return Task.CompletedTask;
  }
}