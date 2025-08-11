using System.ComponentModel.DataAnnotations;

namespace Armada.CQRS.Samples.Features.WeatherForecast.DTOs;

public class WeatherForecastCreateDto
{
  [Required]
  public DateOnly Date { get; set; }
    
  [Required]
  public int TemperatureC { get; set; }
    
  [Required, Length(0, 512)]
  public string Summary { get; set; } = null!;
}