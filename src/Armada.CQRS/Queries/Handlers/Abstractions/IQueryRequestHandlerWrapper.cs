using Armada.CQRS.Handlers.Abstractions;
using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Handlers.Abstractions
{
  public interface IQueryRequestHandlerWrapper<TResponse> : IRequestHandlerWrapper
  {
    Task<TResponse> Handle(IQueryRequest<TResponse> request, IServiceProvider serviceProvider,
      CancellationToken cancellationToken);
  }
}