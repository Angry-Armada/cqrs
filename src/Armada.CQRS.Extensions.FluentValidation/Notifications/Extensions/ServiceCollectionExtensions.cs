using Armada.CQRS.Extensions.FluentValidation.Notifications.Middleware;
using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Extensions.FluentValidation.Notifications.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNotificationFluentValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient(typeof(INotificationMiddleware<>),
            typeof(FluentValidationNotificationMiddleware<>));

        return serviceCollection;
    }
}