namespace Armada.CQRS.Samples.Entities
{
  public class WeatherForecast
  {
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
  }
}
