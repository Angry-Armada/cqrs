using Armada.CQRS.Commands.Extensions;
using Armada.CQRS.Commands.Middleware.Abstractions;
using Armada.CQRS.Notifications.Extensions;
using Armada.CQRS.Notifications.Middleware.Abstraction;
using Armada.CQRS.Queries.Extensions;
using Armada.CQRS.Queries.Middleware.Abstractions;
using Armada.CQRS.Samples;
using Armada.CQRS.Samples.Commands.Middleware;
using Armada.CQRS.Samples.Notifications.Middleware;
using Armada.CQRS.Samples.Queries.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCommandDispatcher()
  .AddCommandHandlers()
  .AddTransient(typeof(ICommandRequestMiddleware<>), typeof(LoggingCommandRequestMiddleware<>))
  .AddTransient(typeof(ICommandRequestMiddleware<,>), typeof(LoggingCommandRequestMiddleware<,>));

builder.Services.AddQueryDispatcher()
  .AddQueryHandlers()
  .AddTransient(typeof(IQueryRequestMiddleware<,>), typeof(LoggingQueryRequestMiddleware<,>));

builder.Services.AddNotificationDispatcher()
  .AddNotificationHandlers()
  .AddTransient(typeof(INotificationRequestMiddleware<>), typeof(LoggingNotificationMiddleware<>));

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
