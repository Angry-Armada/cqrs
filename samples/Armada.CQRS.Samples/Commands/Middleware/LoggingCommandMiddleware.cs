using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Commands.Middleware
{
  public class LoggingCommandMiddleware<TCommand>(
    ILogger<LoggingCommandMiddleware<TCommand>> logger)
    : ICommandMiddleware<TCommand> where TCommand : ICommand
  {
    public async Task HandleAsync(TCommand command, CommandDelegate next,
      CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Command processing: {command}", typeof(TCommand).Name);

      await next(cancellationToken);
    }
  }

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
}