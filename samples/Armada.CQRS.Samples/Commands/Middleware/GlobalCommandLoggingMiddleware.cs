using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Commands.Middleware;

public class GlobalCommandLoggingMiddleware<TCommand, TResponse>(
    ILogger<GlobalCommandLoggingMiddleware<TCommand, TResponse>> logger)
    : ICommandMiddleware<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    public Task<TResponse> HandleAsync(TCommand command, CommandDelegate<TResponse> next,
        CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Command Processing: {command}", typeof(TCommand).Name);

        return next(cancellationToken);
    }
}