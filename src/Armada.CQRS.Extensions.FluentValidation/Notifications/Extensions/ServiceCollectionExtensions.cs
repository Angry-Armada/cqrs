using Armada.CQRS.Extensions.FluentValidation.Notifications.Middleware;
using Armada.CQRS.Notifications.Extensions;

namespace Armada.CQRS.Extensions.FluentValidation.Notifications.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNotificationFluentValidation(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddGlobalNotificationMiddleware(typeof(FluentValidationNotificationMiddleware<>));

        return serviceCollection;
    }
}