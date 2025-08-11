using Armada.CQRS.Commands.Contracts.Abstractions;
using System.Collections.Concurrent;
using Armada.CQRS.Commands.Dispatchers.Abstractions;
using Armada.CQRS.Commands.Handlers;
using Armada.CQRS.Commands.Handlers.Abstractions;

namespace Armada.CQRS.Commands.Dispatchers;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
  private static readonly ConcurrentDictionary<Type, IRequestHandlerWrapper> RequestHandlerWrappers = new();

  public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command,
    CancellationToken cancellationToken = default)
  {
    var handlerWrapper = (ICommandHandlerWrapper<TResponse>)RequestHandlerWrappers.GetOrAdd(command.GetType(),
      static commandType =>
      {
        var wrapperType = typeof(CommandHandlerWrapper<,>).MakeGenericType(commandType, typeof(TResponse));
        var wrapper = Activator.CreateInstance(wrapperType);
        return (IRequestHandlerWrapper)wrapper!;
      });

    return handlerWrapper.Handle(command, serviceProvider, cancellationToken);
  }
}