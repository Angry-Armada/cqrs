using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Middleware.Abstractions
{
  public delegate Task<TResponse> QueryDelegate<TResponse>(CancellationToken cancellationToken = default);
  
  public interface IQueryMiddleware<in TQuery, TResponse> where TQuery : IQuery<TResponse>
  {
    Task<TResponse> HandleAsync(TQuery query,
      QueryDelegate<TResponse> next,
      CancellationToken cancellationToken = default);
  }
}