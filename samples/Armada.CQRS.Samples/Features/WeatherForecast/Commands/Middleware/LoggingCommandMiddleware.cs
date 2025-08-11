using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Commands.Middleware;

public class LoggingCommandMiddleware<TCommand, TResponse>(
  ILogger<LoggingCommandMiddleware<TCommand, TResponse>> logger)
  : ICommandMiddleware<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
  public async Task<TResponse> HandleAsync(TCommand command,
    CommandDelegate<TResponse> next, CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Command processing: {command}", typeof(TCommand).Name);

    return await next(cancellationToken);
  }
}