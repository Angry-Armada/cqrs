namespace Armada.CQRS.Commands.Contracts.Abstractions;

public interface ICommandRequest : IRequest<int>;

public interface ICommandRequest<out TResponse> : IRequest<TResponse>;