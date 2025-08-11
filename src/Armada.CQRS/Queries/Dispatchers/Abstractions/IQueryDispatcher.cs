using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Dispatchers.Abstractions;

public interface IQueryDispatcher
{
  Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query,
    CancellationToken cancellationToken = default);
}