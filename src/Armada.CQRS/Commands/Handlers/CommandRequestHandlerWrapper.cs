using Armada.CQRS.Commands.Handlers.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;
using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Handlers
{
  public class CommandRequestHandlerWrapper<TCommand> : ICommandRequestHandlerWrapper
    where TCommand : ICommandRequest
  {
    public Task Handle(ICommandRequest request, IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
      var aggregation = serviceProvider.GetServices<ICommandRequestMiddleware<TCommand>>()
        .Reverse()
        .Aggregate((CommandRequestDelegate)HandlerDelegate,
          (next, middleware) => ct => middleware.HandleAsync((TCommand)request, next, ct));

      return aggregation(cancellationToken);

      async Task HandlerDelegate(CancellationToken ct)
      {
        var handler = serviceProvider.GetRequiredService<ICommandRequestHandler<TCommand>>();
        await handler.Handle((TCommand)request, ct);
      }
    }
  }

  public class CommandRequestHandlerWrapper<TCommand, TResponse> : ICommandRequestHandlerWrapper<TResponse>
    where TCommand : ICommandRequest<TResponse>
  {
    public Task<TResponse> Handle(ICommandRequest<TResponse> request, IServiceProvider serviceProvider,
      CancellationToken cancellationToken)
    {
      var aggregation = serviceProvider.GetServices<ICommandRequestMiddleware<TCommand, TResponse>>()
        .Reverse()
        .Aggregate((CommandRequestDelegate<TResponse>)HandlerDelegate,
          (next, middleware) => ct => middleware.HandleAsync((TCommand)request, next, ct));

      return aggregation(cancellationToken);

      Task<TResponse> HandlerDelegate(CancellationToken ct)
      {
        var handler = serviceProvider.GetRequiredService<ICommandRequestHandler<TCommand, TResponse>>();
        return handler.Handle((TCommand)request, ct);
      }
    }
  }
}