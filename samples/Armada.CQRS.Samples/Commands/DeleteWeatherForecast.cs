using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Samples.Commands
{
  public record DeleteWeatherForecast(Guid Id) : ICommandRequest;
}