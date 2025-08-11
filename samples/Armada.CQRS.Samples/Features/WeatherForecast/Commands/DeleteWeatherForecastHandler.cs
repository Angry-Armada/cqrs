using Armada.CQRS.Commands.Handlers.Abstractions;

namespace Armada.CQRS.Samples.Features.WeatherForecast.Commands;

public class DeleteWeatherForecastHandler(
  ILogger<DeleteWeatherForecastHandler> logger,
  IForecastStore forecastStore) 
  : ICommandHandler<DeleteWeatherForecast, Result>
{
  public Task<Result> Handle(DeleteWeatherForecast command, CancellationToken cancellationToken = default)
  {
    logger.LogInformation("Deleting Weather Forecast");

    forecastStore.Delete(command.Id);

    return Task.FromResult(Result.Ok());
  }
}