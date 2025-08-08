using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Middleware.Abstractions
{
  public delegate Task CommandDelegate(CancellationToken cancellationToken = default);
  
  public interface ICommandMiddleware<in TCommand> where TCommand : ICommand
  {
    Task HandleAsync(TCommand command,
      CommandDelegate next,
      CancellationToken cancellationToken = default);
  }
  
  public delegate Task<TResponse> CommandDelegate<TResponse>(CancellationToken cancellationToken = default);

  public interface ICommandMiddleware<in TCommand, TResponse> where TCommand : ICommand<TResponse>
  {
    Task<TResponse> HandleAsync(TCommand command,
      CommandDelegate<TResponse> next,
      CancellationToken cancellationToken = default);
  }
}