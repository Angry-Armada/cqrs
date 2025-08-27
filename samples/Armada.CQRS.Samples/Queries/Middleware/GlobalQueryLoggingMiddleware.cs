using Armada.CQRS.Queries.Contracts.Abstractions;
using Armada.CQRS.Queries.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Queries.Middleware;

public class GlobalQueryLoggingMiddleware<TQuery, TResponse>(
    ILogger<GlobalQueryLoggingMiddleware<TQuery, TResponse>> logger) 
    : IQueryMiddleware<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    public Task<TResponse> HandleAsync(TQuery query,
        QueryDelegate<TResponse> next, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Query Processing: {query}", typeof(TQuery).Name);
      
        return next(cancellationToken);
    }
}