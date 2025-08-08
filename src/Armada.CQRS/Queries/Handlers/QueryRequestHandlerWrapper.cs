using Armada.CQRS.Queries.Handlers.Abstractions;
using Armada.CQRS.Queries.Middleware.Abstractions;
using Armada.CQRS.Queries.Contracts.Abstractions;

namespace Armada.CQRS.Queries.Handlers
{
  public class QueryRequestHandlerWrapper<TQuery, TResponse> : IQueryRequestHandlerWrapper<TResponse>
    where TQuery : IQueryRequest<TResponse>
  {
    public Task<TResponse> Handle(IQueryRequest<TResponse> request, IServiceProvider serviceProvider,
      CancellationToken cancellationToken)
    {
      var aggregation = serviceProvider.GetServices<IQueryRequestMiddleware<TQuery, TResponse>>()
        .Reverse()
        .Aggregate((QueryRequestDelegate<TResponse>)HandlerDelegate,
          (next, middleware) => cts => middleware.HandleAsync((TQuery)request, next, cts));

      return aggregation(cancellationToken);

      Task<TResponse> HandlerDelegate(CancellationToken ct)
      {
        var handler = serviceProvider.GetRequiredService<IQueryRequestHandler<TQuery, TResponse>>();
        return handler.Handle((TQuery)request, ct);
      }
    }
  }
}