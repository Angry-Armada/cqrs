using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Commands;

public record DeleteWeatherForecast(Guid Id) : ICommand<Result>;