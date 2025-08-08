using Armada.CQRS.Commands.Contracts.Abstractions;
using System.Collections.Concurrent;
using Armada.CQRS.Commands.Dispatchers.Abstractions;
using Armada.CQRS.Commands.Handlers;
using Armada.CQRS.Commands.Handlers.Abstractions;

namespace Armada.CQRS.Commands.Dispatchers;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
  private readonly ConcurrentDictionary<Type, IRequestHandlerWrapper> _requestHandlerWrappers = new();

  public Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
    where TCommand : ICommand
  {
    var handlerWrapper = (ICommandHandlerWrapper)_requestHandlerWrappers.GetOrAdd(command.GetType(),
      static _ =>
      {
        var wrapper = new CommandHandlerWrapper<TCommand>();
        return wrapper;
      });

    return handlerWrapper.Handle(command, serviceProvider, cancellationToken);
  }

  public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command,
    CancellationToken cancellationToken = default)
  {
    var handlerWrapper = (ICommandHandlerWrapper<TResponse>)_requestHandlerWrappers.GetOrAdd(command.GetType(),
      static commandType =>
      {
        var wrapperType = typeof(CommandHandlerWrapper<,>).MakeGenericType(commandType, typeof(TResponse));
        var wrapper = Activator.CreateInstance(wrapperType);
        return (IRequestHandlerWrapper)wrapper!;
      });

    return handlerWrapper.Handle(command, serviceProvider, cancellationToken);
  }
}