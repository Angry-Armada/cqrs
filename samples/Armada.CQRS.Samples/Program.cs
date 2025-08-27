using System.Reflection;
using Armada.CQRS.Commands.Extensions;
using Armada.CQRS.Extensions.FluentValidation.Commands.Extensions;
using Armada.CQRS.Extensions.FluentValidation.Queries.Extensions;
using Armada.CQRS.Notifications.Extensions;
using Armada.CQRS.Notifications.Middleware.Abstraction;
using Armada.CQRS.Queries.Extensions;
using Armada.CQRS.Queries.Middleware.Abstractions;
using Armada.CQRS.Samples;
using Armada.CQRS.Samples.Commands.Middleware;
using Armada.CQRS.Samples.Features.WeatherForecast.Commands;
using Armada.CQRS.Samples.Features.WeatherForecast.Commands.Middleware;
using Armada.CQRS.Samples.Features.WeatherForecast.Notifications.Middleware;
using Armada.CQRS.Samples.Features.WeatherForecast.Queries.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);

builder.Services.AddCommandDispatcher()
  .AddCommandHandlers()
  .AddGlobalCommandMiddleware(typeof(GlobalCommandLoggingMiddleware<,>))
  .AddSpecificCommandMiddleware<WeatherForecastCreateCommandLoggingMiddleware, CreateWeatherForecast, Guid>()
  .AddCommandFluentValidation();

builder.Services.AddQueryDispatcher()
  .AddQueryHandlers()
  .AddQueryFluentValidation()
  .AddTransient(typeof(IQueryMiddleware<,>), typeof(WeatherForecastQueryLoggingMiddleware<,>));

builder.Services.AddNotificationDispatcher()
  .AddNotificationHandlers()
  .AddTransient(typeof(INotificationMiddleware<>), typeof(WeatherForecastNotificationLoggingMiddleware<>));

builder.Services.AddSingleton<IForecastStore, ForecastStore>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
