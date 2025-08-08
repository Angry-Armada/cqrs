using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Commands.Middleware
{
  public class LoggingCommandRequestMiddleware<TCommand>(
    ILogger<LoggingCommandRequestMiddleware<TCommand>> logger)
    : ICommandRequestMiddleware<TCommand> where TCommand : ICommandRequest
  {
    public async Task HandleAsync(TCommand command, CommandRequestDelegate next,
      CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Command processing: {command}", typeof(TCommand).Name);

      await next(cancellationToken);
    }
  }

  public class LoggingCommandRequestMiddleware<TCommand, TResponse>(
    ILogger<LoggingCommandRequestMiddleware<TCommand, TResponse>> logger)
    : ICommandRequestMiddleware<TCommand, TResponse> where TCommand : ICommandRequest<TResponse>
  {
    public async Task<TResponse> HandleAsync(TCommand command,
      CommandRequestDelegate<TResponse> next, CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Command processing: {command}", typeof(TCommand).Name);

      return await next(cancellationToken);
    }
  }
}