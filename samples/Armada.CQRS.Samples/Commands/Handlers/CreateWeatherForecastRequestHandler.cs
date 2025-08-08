using Armada.CQRS.Commands.Handlers.Abstractions;
using Armada.CQRS.Notifications.Dispatchers.Abstractions;
using Armada.CQRS.Samples.Entities;
using Armada.CQRS.Samples.Notifications;

namespace Armada.CQRS.Samples.Commands.Handlers
{
  public class CreateWeatherForecastRequestHandler(
    ILogger<CreateWeatherForecastRequestHandler> logger,
    IForecastStore forecastStore,
    INotificationDispatcher notificationDispatcher) 
    : ICommandRequestHandler<CreateWeatherForecast, Guid>
  {
    public async Task<Guid> Handle(CreateWeatherForecast command, CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Creating Weather Forecast");

      var forecast = new WeatherForecast
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
}