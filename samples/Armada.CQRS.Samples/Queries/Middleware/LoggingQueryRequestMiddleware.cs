using Armada.CQRS.Queries.Contracts.Abstractions;
using Armada.CQRS.Queries.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Queries.Middleware
{
  public class LoggingQueryRequestMiddleware<TQuery, TResponse>(
    ILogger<LoggingQueryRequestMiddleware<TQuery, TResponse>> logger) 
    : IQueryRequestMiddleware<TQuery, TResponse> where TQuery : IQueryRequest<TResponse>
  {
    public Task<TResponse> HandleAsync(TQuery query,
      QueryRequestDelegate<TResponse> next, CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Query processing: {query}", typeof(TQuery).Name);
      
      return next(cancellationToken);
    }
  }
}