using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Handlers.Abstractions;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
  Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken = default);
}