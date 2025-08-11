namespace Armada.CQRS.Samples.Features.WeatherForecast.Entities;

public class WeatherForecast
{
  public Guid Id { get; init; }
  public DateOnly Date { get; init; }
  public int TemperatureC { get; init; }
  public string? Summary { get; set; }
}