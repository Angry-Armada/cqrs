using Armada.CQRS.Commands.Contracts.Abstractions;
using Armada.CQRS.Commands.Middleware.Abstractions;

namespace Armada.CQRS.Extensions.FluentValidation.Commands.Middleware;

public class FluentValidationCommandMiddleware<TCommand, TResponse>(
    IEnumerable<IValidator<TCommand>> validators)
    : ICommandMiddleware<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    public async Task<TResponse> HandleAsync(TCommand command, CommandDelegate<TResponse> next,
        CancellationToken cancellationToken = default)
    {
        var context = new ValidationContext<TCommand>(command);
        var validationTasks = validators.Select(v => v.ValidateAsync(context, cancellationToken));
        var validationResults = await Task.WhenAll(validationTasks);

        var failures = validationResults
            .Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .ToArray();

        if (failures.Length != 0)
        {
            throw new ValidationException(failures);
        }

        return await next(cancellationToken);
    }
}