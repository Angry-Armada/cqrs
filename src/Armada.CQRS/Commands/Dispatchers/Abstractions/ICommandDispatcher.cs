using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Dispatchers.Abstractions;

public interface ICommandDispatcher
{
  Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
    where TCommand : ICommandRequest;

  Task<TResponse> SendAsync<TResponse>(ICommandRequest<TResponse> command,
    CancellationToken cancellationToken = default);
}