using Armada.CQRS.Commands.Extensions;
using Armada.CQRS.Extensions.FluentValidation.Commands.Middleware;

namespace Armada.CQRS.Extensions.FluentValidation.Commands.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCommandFluentValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddGlobalCommandMiddleware(typeof(FluentValidationCommandMiddleware<,>));
        
        return serviceCollection;
    }
}