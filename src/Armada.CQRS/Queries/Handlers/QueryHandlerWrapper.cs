using Armada.CQRS.Queries.Handlers.Abstractions;
using Armada.CQRS.Queries.Middleware.Abstractions;
using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Handlers
{
  public class QueryHandlerWrapper<TQuery, TResponse> : IQueryHandlerWrapper<TResponse>
    where TQuery : IQuery<TResponse>
  {
    public Task<TResponse> Handle(IQuery<TResponse> request, IServiceProvider serviceProvider,
      CancellationToken cancellationToken)
    {
      var aggregation = serviceProvider.GetServices<IQueryMiddleware<TQuery, TResponse>>()
        .Reverse()
        .Aggregate((QueryDelegate<TResponse>)HandlerDelegate,
          (next, middleware) => cts => middleware.HandleAsync((TQuery)request, next, cts));

      return aggregation(cancellationToken);

      Task<TResponse> HandlerDelegate(CancellationToken ct)
      {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
        return handler.Handle((TQuery)request, ct);
      }
    }
  }
}