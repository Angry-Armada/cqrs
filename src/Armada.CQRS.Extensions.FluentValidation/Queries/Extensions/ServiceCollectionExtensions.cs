using Armada.CQRS.Extensions.FluentValidation.Queries.Middleware;
using Armada.CQRS.Queries.Extensions;

namespace Armada.CQRS.Extensions.FluentValidation.Queries.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQueryFluentValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddGlobalQueryMiddleware(typeof(FluentValidationQueryMiddleware<,>));
        
        return serviceCollection;
    }
}