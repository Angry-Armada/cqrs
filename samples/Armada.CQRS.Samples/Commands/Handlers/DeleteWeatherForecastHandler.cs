using Armada.CQRS.Commands.Handlers.Abstractions;

namespace Armada.CQRS.Samples.Commands.Handlers
{
  public class DeleteWeatherForecastHandler(
    ILogger<DeleteWeatherForecastHandler> logger,
    IForecastStore forecastStore) 
    : ICommandHandler<DeleteWeatherForecast>
  {
    public Task Handle(DeleteWeatherForecast command, CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Deleting Weather Forecast");

      forecastStore.Delete(command.Id);
      
      return Task.CompletedTask;
    }
  }
}