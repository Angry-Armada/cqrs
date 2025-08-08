using Armada.CQRS.Handlers.Abstractions;
using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Handlers.Abstractions;

public interface ICommandRequestHandlerWrapper : IRequestHandlerWrapper
{
    Task Handle(ICommandRequest request, IServiceProvider serviceProvider,
        CancellationToken cancellationToken);
}

public interface ICommandRequestHandlerWrapper<TResponse> : IRequestHandlerWrapper
{
    Task<TResponse> Handle(ICommandRequest<TResponse> request, IServiceProvider serviceProvider,
        CancellationToken cancellationToken);
}