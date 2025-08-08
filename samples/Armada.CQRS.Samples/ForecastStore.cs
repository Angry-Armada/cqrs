using System.Collections.Concurrent;
using Armada.CQRS.Samples.Entities;

namespace Armada.CQRS.Samples
{
  public interface IForecastStore
  {
    void Add(Guid id, WeatherForecast forecast);
    void Delete(Guid id);
    ICollection<WeatherForecast> GetAll();
  }
  
  public class ForecastStore : IForecastStore
  {
    private readonly ConcurrentDictionary<Guid, WeatherForecast> _dictionary = new();
    
    public void Add(Guid id, WeatherForecast forecast)
    {
      _dictionary.TryAdd(id, forecast);
    }

    public void Delete(Guid id)
    {
      _dictionary.TryRemove(id, out _);
    }

    public ICollection<WeatherForecast> GetAll()
    {
      return _dictionary.Values;
    }
  }
}