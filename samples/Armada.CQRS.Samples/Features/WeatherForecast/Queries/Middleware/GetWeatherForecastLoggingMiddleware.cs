using Armada.CQRS.Queries.Middleware.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Queries.Middleware;

public class GetWeatherForecastLoggingMiddleware(
  ILogger<GetWeatherForecastLoggingMiddleware> logger) 
  : IQueryMiddleware<GetWeatherForecast, IEnumerable<Entities.WeatherForecast>>
{

  public async Task<IEnumerable<Entities.WeatherForecast>> HandleAsync(GetWeatherForecast query, 
    QueryDelegate<IEnumerable<Entities.WeatherForecast>> next, CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Get Weather Forecast Processing...");
      
    var result = await next(cancellationToken);
    
    logger.LogInformation("Get Weather Forecast Completed: {count} items", result.Count());

    return result;
  }
}