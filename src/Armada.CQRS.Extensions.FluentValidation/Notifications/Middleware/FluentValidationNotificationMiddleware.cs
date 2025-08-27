using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Extensions.FluentValidation.Notifications.Middleware;

public class FluentValidationNotificationMiddleware<TNotification>(
    IEnumerable<IValidator<TNotification>> validators)
    : INotificationMiddleware<TNotification>
    where TNotification : INotification
{
    public async Task HandleAsync(TNotification notification, NotificationDelegate next,
        CancellationToken cancellationToken = default)
    {
        var context = new ValidationContext<TNotification>(notification);
        var validationTasks = validators.Select(v => v.ValidateAsync(context, cancellationToken));
        var validationResults = await Task.WhenAll(validationTasks);

        var failures = validationResults
            .Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .ToArray();

        if (failures.Length != 0)
        {
            throw new ValidationException(failures);
        }

        await next(cancellationToken);
    }
}