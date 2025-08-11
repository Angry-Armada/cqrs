using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Queries;

public record GetWeatherForecast : IQuery<IEnumerable<Entities.WeatherForecast>>;