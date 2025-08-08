namespace Armada.CQRS.Contracts.Abstractions
{
  public interface IRequest;
  public interface IRequest<out TResponse> : IRequest;
}