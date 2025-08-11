using Armada.CQRS.Queries.Handlers.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Queries;

public class GetWeatherForecastHandler(IForecastStore forecastStore)
  : IQueryHandler<GetWeatherForecast, IEnumerable<Entities.WeatherForecast>>
{
  public Task<IEnumerable<Entities.WeatherForecast>> Handle(GetWeatherForecast query,
    CancellationToken cancellationToken = default)
  {
    var result = forecastStore.GetAll();
    return Task.FromResult<IEnumerable<Entities.WeatherForecast>>(result);
  }
}