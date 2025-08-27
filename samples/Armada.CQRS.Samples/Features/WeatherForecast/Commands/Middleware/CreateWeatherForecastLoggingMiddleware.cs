using System.Text.Json;
using Armada.CQRS.Commands.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Commands.Middleware;

public class CreateWeatherForecastLoggingMiddleware(
    ILogger<CreateWeatherForecastLoggingMiddleware> logger)
    : ICommandMiddleware<CreateWeatherForecast, Guid>
{
    public Task<Guid> HandleAsync(CreateWeatherForecast command,
        CommandDelegate<Guid> next, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Weather Forecast Create Command Processing: {payload}",
            JsonSerializer.Serialize(command.Payload));

        return next(cancellationToken);
    }
}