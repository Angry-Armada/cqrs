using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Handlers.Abstractions;

public interface ICommandHandlerWrapper<TResponse> : IRequestHandlerWrapper
{
    Task<TResponse> Handle(ICommand<TResponse> request, IServiceProvider serviceProvider,
        CancellationToken cancellationToken);
}