using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Dispatchers.Abstractions;

public interface ICommandDispatcher
{
  Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command,
    CancellationToken cancellationToken = default);
}