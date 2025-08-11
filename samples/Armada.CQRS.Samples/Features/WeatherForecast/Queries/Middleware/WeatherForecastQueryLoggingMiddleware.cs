using Armada.CQRS.Queries.Contracts.Abstractions;
using Armada.CQRS.Queries.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Queries.Middleware;

public class WeatherForecastQueryLoggingMiddleware<TQuery, TResponse>(
  ILogger<WeatherForecastQueryLoggingMiddleware<TQuery, TResponse>> logger) 
  : IQueryMiddleware<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
  public Task<TResponse> HandleAsync(TQuery query,
    QueryDelegate<TResponse> next, CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Weather Forecast Query Processing: {query}", typeof(TQuery).Name);
      
    return next(cancellationToken);
  }
}