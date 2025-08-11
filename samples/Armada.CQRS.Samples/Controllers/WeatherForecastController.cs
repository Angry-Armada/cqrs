using Armada.CQRS.Commands.Dispatchers.Abstractions;
using Armada.CQRS.Queries.Dispatchers.Abstractions;
using Armada.CQRS.Samples.Features.WeatherForecast.Commands;
using Armada.CQRS.Samples.Features.WeatherForecast.DTOs;
using Armada.CQRS.Samples.Features.WeatherForecast.Entities;
using Armada.CQRS.Samples.Features.WeatherForecast.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Armada.CQRS.Samples.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController(
    IQueryDispatcher queryDispatcher,
    ICommandDispatcher commandDispatcher)
    : ControllerBase
  {
    [HttpGet]
    public Task<IEnumerable<WeatherForecast>> Get()
    {
      var query = new GetWeatherForecast();
      return queryDispatcher.QueryAsync(query);
    }

    [HttpPost]
    public async Task<Guid> Create([FromBody] WeatherForecastCreateDto payload)
    {
      var command = new CreateWeatherForecast(payload);
      return await commandDispatcher.SendAsync(command);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
      var command = new DeleteWeatherForecast(id);
      await commandDispatcher.SendAsync(command);
      return Ok();
    }
  }
}