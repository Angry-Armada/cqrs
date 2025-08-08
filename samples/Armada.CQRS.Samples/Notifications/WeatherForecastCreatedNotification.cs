using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Samples.Entities;

namespace Armada.CQRS.Samples.Notifications
{
  public record WeatherForecastCreatedNotification(WeatherForecast Forecast) : INotificationRequest;
}