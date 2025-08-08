using Armada.CQRS.Commands.Dispatchers;
using Armada.CQRS.Commands.Dispatchers.Abstractions;
using Armada.CQRS.Commands.Handlers.Abstractions;

namespace Armada.CQRS.Commands.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddCommandDispatcher(this IServiceCollection serviceCollection)
  {
    serviceCollection.AddSingleton<ICommandDispatcher, CommandDispatcher>();
      
    return serviceCollection;
  }
    
  public static IServiceCollection AddCommandHandlers(this IServiceCollection serviceCollection)
  {
    serviceCollection.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
      .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
      .UsingRegistrationStrategy(RegistrationStrategy.Skip)
      .AsImplementedInterfaces()
      .WithTransientLifetime());

    
    serviceCollection.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
      .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
      .UsingRegistrationStrategy(RegistrationStrategy.Skip)
      .AsImplementedInterfaces()
      .WithTransientLifetime());

    return serviceCollection;
  }
}