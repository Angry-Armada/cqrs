using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Middleware.Abstractions
{
  public delegate Task<TResponse> QueryRequestDelegate<TResponse>(CancellationToken cancellationToken = default);
  
  public interface IQueryRequestMiddleware<in TQuery, TResponse> where TQuery : IQueryRequest<TResponse>
  {
    Task<TResponse> HandleAsync(TQuery query,
      QueryRequestDelegate<TResponse> next,
      CancellationToken cancellationToken = default);
  }
}