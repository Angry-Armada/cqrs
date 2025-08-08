using Armada.CQRS.Queries.Contracts.Abstractions;
using Armada.CQRS.Samples.Entities;

namespace Armada.CQRS.Samples.Queries
{
  public record GetWeatherForecast : IQuery<IEnumerable<WeatherForecast>>;
}