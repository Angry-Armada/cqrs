using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Handlers.Abstractions
{
  public interface IQueryRequestHandler<in TQuery, TResponse> where TQuery : IQueryRequest<TResponse>
  {
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken = default);
  }
}