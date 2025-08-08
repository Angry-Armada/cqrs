using Armada.CQRS.Queries.Handlers.Abstractions;
using Armada.CQRS.Samples.Entities;

namespace Armada.CQRS.Samples.Queries.Handlers
{
  public class GetWeatherForecastHandler(IForecastStore forecastStore)
    : IQueryHandler<GetWeatherForecast, IEnumerable<WeatherForecast>>
  {
    public Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecast query,
      CancellationToken cancellationToken = default)
    {
      var result = forecastStore.GetAll();
      return Task.FromResult<IEnumerable<WeatherForecast>>(result);
    }
  }
}