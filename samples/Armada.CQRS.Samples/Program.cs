using System.Reflection;
using Armada.CQRS.Commands.Extensions;
using Armada.CQRS.Commands.Middleware.Abstractions;
using Armada.CQRS.Extensions.FluentValidation.Commands.Extensions;
using Armada.CQRS.Extensions.FluentValidation.Queries.Extensions;
using Armada.CQRS.Notifications.Extensions;
using Armada.CQRS.Notifications.Middleware.Abstraction;
using Armada.CQRS.Queries.Extensions;
using Armada.CQRS.Queries.Middleware.Abstractions;
using Armada.CQRS.Samples;
using Armada.CQRS.Samples.Features.WeatherForecast.Commands.Middleware;
using Armada.CQRS.Samples.Features.WeatherForecast.Notifications.Middleware;
using Armada.CQRS.Samples.Features.WeatherForecast.Queries.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);

builder.Services.AddCommandDispatcher()
  .AddCommandHandlers()
  .AddCommandFluentValidation()
  .AddTransient(typeof(ICommandMiddleware<,>), typeof(WeatherForecastCommandLoggingMiddleware<,>));

builder.Services.AddQueryDispatcher()
  .AddQueryHandlers()
  .AddQueryFluentValidation()
  .AddTransient(typeof(IQueryMiddleware<,>), typeof(WeatherForecastQueryLoggingMiddleware<,>));

builder.Services.AddNotificationDispatcher()
  .AddNotificationHandlers()
  .AddTransient(typeof(INotificationMiddleware<>), typeof(WeatherForecastNotificationLoggingMiddleware<>));

builder.Services.AddSingleton<IForecastStore, ForecastStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
