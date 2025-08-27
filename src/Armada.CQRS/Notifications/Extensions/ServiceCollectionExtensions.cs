using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Dispatchers;
using Armada.CQRS.Notifications.Dispatchers.Abstractions;
using Armada.CQRS.Notifications.Handlers.Abstractions;
using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Notifications.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddNotificationDispatcher(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddSingleton<INotificationDispatcher, NotificationDispatcher>();
      
    return serviceCollection;
  }
    
  public static IServiceCollection AddNotificationHandlers(this IServiceCollection serviceCollection)
  {
    serviceCollection.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
      .AddClasses(c => c.AssignableTo(typeof(INotificationHandler<>)))
      .AsImplementedInterfaces()
      .WithTransientLifetime());

    return serviceCollection;
  }
  
  public static IServiceCollection AddGlobalNotificationMiddleware(
    this IServiceCollection services, Type middleware)
  {
    services.AddTransient(typeof(INotificationMiddleware<>), middleware);
    return services;
  }
    
  public static IServiceCollection AddSpecificNotificationMiddleware<TNotificationMiddleware, TNotification>(
    this IServiceCollection services) where TNotificationMiddleware : INotificationMiddleware<TNotification>
    where TNotification : INotification
  {
    services.AddTransient(typeof(INotificationMiddleware<TNotification>), typeof(TNotificationMiddleware));
    return services;
  }
}