using Armada.CQRS.Notifications.Contracts.Abstractions;
using Armada.CQRS.Notifications.Handlers.Abstractions;
using Armada.CQRS.Notifications.Middleware.Abstraction;

namespace Armada.CQRS.Notifications.Handlers
{
  public class NotificationRequestHandlerWrapper<TNotification> : INotificationRequestHandlerWrapper
    where TNotification : INotificationRequest
  {
    public Task Handle(INotificationRequest notification,
      IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
      var aggregation = serviceProvider.GetServices<INotificationRequestMiddleware<TNotification>>()
        .Reverse()
        .Aggregate((NotificationRequestDelegate)HandlerDelegate,
          (next, middleware) => ct => middleware.HandleAsync((TNotification)notification, next, ct));

      return aggregation(cancellationToken);
      
      async Task HandlerDelegate(CancellationToken ct)
      {
        var handlers = serviceProvider.GetServices<INotificationRequestHandler<TNotification>>();
        foreach (var handler in handlers)
        {
          await handler.Handle((TNotification)notification, cancellationToken);
        }
      }
    }
  }
}