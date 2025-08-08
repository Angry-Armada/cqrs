using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Handlers.Abstractions;
using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Notifications.Handlers
{
  public class NotificationHandlerWrapper<TNotification> : INotificationHandlerWrapper
    where TNotification : INotification
  {
    public Task Handle(INotification notification,
      IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
      var aggregation = serviceProvider.GetServices<INotificationMiddleware<TNotification>>()
        .Reverse()
        .Aggregate((NotificationDelegate)HandlerDelegate,
          (next, middleware) => ct => middleware.HandleAsync((TNotification)notification, next, ct));

      return aggregation(cancellationToken);
      
      async Task HandlerDelegate(CancellationToken ct)
      {
        var handlers = serviceProvider.GetServices<INotificationHandler<TNotification>>();
        foreach (var handler in handlers)
        {
          await handler.Handle((TNotification)notification, ct);
        }
      }
    }
  }
}