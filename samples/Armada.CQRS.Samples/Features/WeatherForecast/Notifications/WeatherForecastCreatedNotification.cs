using Armada.CQRS.Notifications.Contracts.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Notifications;

public record WeatherForecastCreatedNotification(Entities.WeatherForecast Forecast) : INotification;