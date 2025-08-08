using Armada.CQRS.Commands.Handlers.Abstractions;

namespace Armada.CQRS.Samples.Commands.Handlers
{
  public class DeleteWeatherForecastRequestHandler(
    ILogger<DeleteWeatherForecastRequestHandler> logger,
    IForecastStore forecastStore) 
    : ICommandRequestHandler<DeleteWeatherForecast>
  {
    public Task Handle(DeleteWeatherForecast command, CancellationToken cancellationToken = default)
    {
      logger.LogInformation("Deleting Weather Forecast");

      forecastStore.Delete(command.Id);
      
      return Task.CompletedTask;
    }
  }
}