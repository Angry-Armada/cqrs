using Armada.CQRS.Commands.Handlers.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;
using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Handlers;

public class CommandHandlerWrapper<TCommand, TResponse> : ICommandHandlerWrapper<TResponse>
  where TCommand : ICommand<TResponse>
{
  public Task<TResponse> Handle(ICommand<TResponse> request, IServiceProvider serviceProvider,
    CancellationToken cancellationToken)
  {
    var aggregation = serviceProvider.GetServices<ICommandMiddleware<TCommand, TResponse>>()
      .Reverse()
      .Aggregate((CommandDelegate<TResponse>)HandlerDelegate,
        (next, middleware) => ct => middleware.HandleAsync((TCommand)request, next, ct));

    return aggregation(cancellationToken);

    Task<TResponse> HandlerDelegate(CancellationToken ct)
    {
      var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResponse>>();
      return handler.Handle((TCommand)request, ct);
    }
  }
}