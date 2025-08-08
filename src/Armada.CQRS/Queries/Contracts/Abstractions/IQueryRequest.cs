namespace Armada.CQRS.Queries.Contracts.Abstractions
{
  public interface IQueryRequest<out TResponse> : IRequest<TResponse>;
}