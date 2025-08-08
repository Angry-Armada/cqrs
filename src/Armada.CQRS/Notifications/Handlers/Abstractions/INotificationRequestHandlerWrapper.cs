using Armada.CQRS.Handlers.Abstractions;
using Armada.CQRS.Notifications.Contracts.Abstractions;

namespace Armada.CQRS.Notifications.Handlers.Abstractions
{
  public interface INotificationRequestHandlerWrapper : IRequestHandlerWrapper
  {
    Task Handle(INotificationRequest notification, IServiceProvider serviceProvider,
      CancellationToken cancellationToken);
  }
}