using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Commands.Dispatchers;
using Armada.CQRS.Commands.Dispatchers.Abstractions;
using Armada.CQRS.Commands.Handlers.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;

namespace Armada.CQRS.Commands.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommandDispatcher(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ICommandDispatcher, CommandDispatcher>();

        return serviceCollection;
    }

    public static IServiceCollection AddCommandHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return serviceCollection;
    }
    
    public static IServiceCollection AddGlobalCommandMiddleware(
        this IServiceCollection services, Type middleware)
    {
        services.AddTransient(typeof(ICommandMiddleware<,>), middleware);
        return services;
    }
    
    public static IServiceCollection AddSpecificCommandMiddleware<TCommandMiddleware, TCommand, TResponse>(
        this IServiceCollection services) where TCommandMiddleware : ICommandMiddleware<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        services.AddTransient(typeof(ICommandMiddleware<TCommand, TResponse>), typeof(TCommandMiddleware));
        return services;
    }
}