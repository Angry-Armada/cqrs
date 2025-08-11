using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Samples.Features.WeatherForecast.DTOs;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Commands;

public record CreateWeatherForecast(WeatherForecastCreateDto Payload) : ICommand<Guid>;