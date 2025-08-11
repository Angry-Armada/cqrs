namespace Armada.CQRS.Samples.Features.WeatherForecast.Queries.Validators;

public class GetWeatherForecastValidator : AbstractValidator<GetWeatherForecast>
{
    public GetWeatherForecastValidator(ILogger<GetWeatherForecastValidator> logger)
    {
        logger.LogInformation("Get Weather Forecast Validator initialized");
    }
}