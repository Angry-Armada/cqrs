using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Commands.Middleware;

public class WeatherForecastCommandLoggingMiddleware<TCommand, TResponse>(
  ILogger<WeatherForecastCommandLoggingMiddleware<TCommand, TResponse>> logger)
  : ICommandMiddleware<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
  public async Task<TResponse> HandleAsync(TCommand command,
    CommandDelegate<TResponse> next, CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Weather Forecast Command Processing: {command}", typeof(TCommand).Name);

    return await next(cancellationToken);
  }
}