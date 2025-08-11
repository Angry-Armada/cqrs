using Armada.CQRS.Notifications.Dispatchers.Abstractions;
using Armada.CQRS.Samples.Features.WeatherForecast.Notifications;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Commands;

public class CreateWeatherForecastHandler(
  ILogger<CreateWeatherForecastHandler> logger,
  IForecastStore forecastStore,
  INotificationDispatcher notificationDispatcher) 
  : ICommandHandler<CreateWeatherForecast, Guid>
{
  public async Task<Guid> Handle(CreateWeatherForecast command, CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Creating Weather Forecast");

    var forecast = new Entities.WeatherForecast
    {
      Id = Guid.NewGuid(),
      Date = command.Payload.Date,
      TemperatureC = command.Payload.TemperatureC,
      Summary = command.Payload.Summary
    };

    forecastStore.Add(forecast.Id, forecast);

    var notification = new WeatherForecastCreatedNotification(forecast);
    await notificationDispatcher.PublishAsync(notification, cancellationToken);
      
    return Guid.NewGuid();
  }
}