using Armada.CQRS.Queries.Contracts.Abstractions;
using System.Collections.Concurrent;
using Armada.CQRS.Handlers.Abstractions;
using Armada.CQRS.Queries.Dispatchers.Abstractions;
using Armada.CQRS.Queries.Handlers;
using Armada.CQRS.Queries.Handlers.Abstractions;

namespace Armada.CQRS.Queries.Dispatchers
{
  public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
  {
    private readonly ConcurrentDictionary<Type, IRequestHandlerWrapper> _requestHandlerWrappers = new();
    
    public Task<TResponse> QueryAsync<TResponse>(IQueryRequest<TResponse> query,
      CancellationToken cancellationToken = default)
    {
      var handlerWrapper = (IQueryRequestHandlerWrapper<TResponse>)_requestHandlerWrappers.GetOrAdd(query.GetType(),
        static queryType =>
        {
          var wrapperType = typeof(QueryRequestHandlerWrapper<,>).MakeGenericType(queryType, typeof(TResponse));
          var wrapper = Activator.CreateInstance(wrapperType);
          return (IRequestHandlerWrapper)wrapper!;
        });

      return handlerWrapper.Handle(query, serviceProvider, cancellationToken);
    }
  }
}