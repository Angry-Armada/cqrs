using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Handlers.Abstractions;

public interface ICommandRequestHandler<in TCommand> where TCommand : ICommandRequest
{
  Task Handle(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandRequestHandler<in TCommand, TResponse> where TCommand : ICommandRequest<TResponse>
{
  Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken = default);
}