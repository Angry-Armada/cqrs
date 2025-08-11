using Armada.CQRS.Notifications.Contracts.Abstractions;

namespace Armada.CQRS.Notifications.Handlers.Abstractions;

public interface INotificationHandlerWrapper : IRequestHandlerWrapper
{
  Task Handle(INotification notification, IServiceProvider serviceProvider,
    CancellationToken cancellationToken);
}