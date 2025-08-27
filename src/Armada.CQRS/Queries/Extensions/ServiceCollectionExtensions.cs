using Armada.CQRS.Queries.Contracts.Abstractions;
using Armada.CQRS.Queries.Dispatchers;
using Armada.CQRS.Queries.Dispatchers.Abstractions;
using Armada.CQRS.Queries.Handlers.Abstractions;
using Armada.CQRS.Queries.Middleware.Abstractions;

namespace Armada.CQRS.Queries.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddQueryDispatcher(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddTransient<IQueryDispatcher, QueryDispatcher>();
      
    return serviceCollection;
  }
    
  public static IServiceCollection AddQueryHandlers(this IServiceCollection serviceCollection)
  {
    serviceCollection.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
      .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
      .UsingRegistrationStrategy(RegistrationStrategy.Skip)
      .AsImplementedInterfaces()
      .WithTransientLifetime());

    return serviceCollection;
  }
  
  public static IServiceCollection AddGlobalQueryMiddleware(
    this IServiceCollection services, Type middleware)
  {
    services.AddTransient(typeof(IQueryMiddleware<,>), middleware);
    return services;
  }
    
  public static IServiceCollection AddSpecificQueryMiddleware<TQueryMiddleware, TQuery, TResponse>(
    this IServiceCollection services) where TQueryMiddleware : IQueryMiddleware<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
  {
    services.AddTransient(typeof(IQueryMiddleware<TQuery, TResponse>), typeof(TQueryMiddleware));
    return services;
  }
}