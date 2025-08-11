using Armada.CQRS.FluentValidation.Queries.Middleware;
using Armada.CQRS.Queries.Middleware.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Armada.CQRS.FluentValidation.Queries.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQueryFluentValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient(typeof(IQueryMiddleware<,>), typeof(FluentValidationQueryMiddleware<,>));
        
        return serviceCollection;
    }
}