using Armada.CQRS.Commands.Contracts.Abstractions;

namespace Armada.CQRS.Commands.Middleware.Abstractions
{
  public delegate Task CommandRequestDelegate(CancellationToken cancellationToken = default);
  
  public interface ICommandRequestMiddleware<in TCommand> where TCommand : ICommandRequest
  {
    Task HandleAsync(TCommand command,
      CommandRequestDelegate next,
      CancellationToken cancellationToken = default);
  }
  
  public delegate Task<TResponse> CommandRequestDelegate<TResponse>(CancellationToken cancellationToken = default);

  public interface ICommandRequestMiddleware<in TCommand, TResponse> where TCommand : ICommandRequest<TResponse>
  {
    Task<TResponse> HandleAsync(TCommand command,
      CommandRequestDelegate<TResponse> next,
      CancellationToken cancellationToken = default);
  }
}