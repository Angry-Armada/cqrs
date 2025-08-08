using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Handlers.Abstractions
{
  public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
  {
    Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken = default);
  }
}