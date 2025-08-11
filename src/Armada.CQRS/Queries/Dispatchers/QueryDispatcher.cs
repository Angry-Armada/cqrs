using Armada.CQRS.Queries.Contracts.Abstractions;
using System.Collections.Concurrent;
using Armada.CQRS.Queries.Dispatchers.Abstractions;
using Armada.CQRS.Queries.Handlers;
using Armada.CQRS.Queries.Handlers.Abstractions;

namespace Armada.CQRS.Queries.Dispatchers;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
  private static readonly ConcurrentDictionary<Type, IRequestHandlerWrapper> RequestHandlerWrappers = new();
    
  public Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query,
    CancellationToken cancellationToken = default)
  {
    var handlerWrapper = (IQueryHandlerWrapper<TResponse>)RequestHandlerWrappers.GetOrAdd(query.GetType(),
      static queryType =>
      {
        var wrapperType = typeof(QueryHandlerWrapper<,>).MakeGenericType(queryType, typeof(TResponse));
        var wrapper = Activator.CreateInstance(wrapperType);
        return (IRequestHandlerWrapper)wrapper!;
      });

    return handlerWrapper.Handle(query, serviceProvider, cancellationToken);
  }
}