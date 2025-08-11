using System.Collections.Concurrent;
using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Dispatchers.Abstractions;
using Armada.CQRS.Notifications.Handlers;
using Armada.CQRS.Notifications.Handlers.Abstractions;

namespace Armada.CQRS.Notifications.Dispatchers;

public class NotificationDispatcher(IServiceProvider serviceProvider) : INotificationDispatcher
{
  private readonly ConcurrentDictionary<Type, IRequestHandlerWrapper> _requestHandlerWrappers = new();

  public Task PublishAsync<TNotification>(TNotification notification,
    CancellationToken cancellationToken = default) where TNotification : INotification
  {
    var handlerWrapper = (INotificationHandlerWrapper)_requestHandlerWrappers.GetOrAdd(notification.GetType(),
      static _ =>
      {
        var wrapper = new NotificationHandlerWrapper<TNotification>();
        return wrapper;
      });

    return handlerWrapper.Handle(notification, serviceProvider, cancellationToken);
  }
}