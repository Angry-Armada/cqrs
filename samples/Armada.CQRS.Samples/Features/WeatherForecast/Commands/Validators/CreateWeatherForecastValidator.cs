namespace Armada.CQRS.Samples.Features.WeatherForecast.Commands.Validators;

public class CreateWeatherForecastValidator : AbstractValidator<CreateWeatherForecast>
{
    public CreateWeatherForecastValidator()
    {
        RuleFor(x => x.Payload)
            .NotNull();

        RuleFor(x => x.Payload.Date)
            .Must(date => date >= DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Date must be in the future")
            .WithErrorCode("InvalidDate");
    }
}