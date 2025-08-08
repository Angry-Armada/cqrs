using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Samples.DTOs;

namespace Armada.CQRS.Samples.Commands
{
  public record CreateWeatherForecast(WeatherForecastCreateDto Payload) : ICommand<Guid>;
}
