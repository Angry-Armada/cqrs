namespace Armada.CQRS.Commands.Contracts.Abstractions;

public interface ICommand;

// ReSharper disable once UnusedTypeParameter
public interface ICommand<out TResponse>;