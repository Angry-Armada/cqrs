using System;
using Armada.CQRS.Notifications.Dispatchers;
using Armada.CQRS.Notifications.Dispatchers.Abstractions;
using Armada.CQRS.Notifications.Handlers.Abstractions;

namespace Armada.CQRS.Notifications.Extensions
{
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
        .AddClasses(c => c.AssignableTo(typeof(INotificationRequestHandler<>)))
        .AsImplementedInterfaces()
        .WithTransientLifetime());

      return serviceCollection;
    }
  }
}