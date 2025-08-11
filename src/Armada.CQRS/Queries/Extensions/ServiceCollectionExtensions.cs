using Armada.CQRS.Queries.Dispatchers;
using Armada.CQRS.Queries.Dispatchers.Abstractions;
using Armada.CQRS.Queries.Handlers.Abstractions;

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
}