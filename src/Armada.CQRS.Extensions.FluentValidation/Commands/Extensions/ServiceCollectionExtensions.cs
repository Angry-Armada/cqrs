using Armada.CQRS.Commands.Middleware.Abstractions;
using Armada.CQRS.Extensions.FluentValidation.Commands.Middleware;
using Microsoft.Extensions.DependencyInjection;

namespace Armada.CQRS.Extensions.FluentValidation.Commands.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommandFluentValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient(typeof(ICommandMiddleware<,>), typeof(FluentValidationCommandMiddleware<,>));
        
        return serviceCollection;
    }
}