using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Dispatchers.Abstractions;

public interface ICommandDispatcher
{
  Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
    where TCommand : ICommand;

  Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command,
    CancellationToken cancellationToken = default);
}