namespace Armada.CQRS.Samples.Features.WeatherForecast.Notifications.Validators;

public class WeatherForecastCreatedNotificationValidator : AbstractValidator<WeatherForecastCreatedNotification>
{
    public WeatherForecastCreatedNotificationValidator()
    {
        RuleFor(x => x.Forecast)
            .NotNull();
    }
}