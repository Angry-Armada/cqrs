using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Handlers.Abstractions;

public interface IQueryHandlerWrapper<TResponse> : IRequestHandlerWrapper
{
  Task<TResponse> Handle(IQuery<TResponse> request, IServiceProvider serviceProvider,
    CancellationToken cancellationToken);
}