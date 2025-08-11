using Armada.CQRS.Queries.Contracts.Abstractions;
using Armada.CQRS.Queries.Middleware.Abstractions;
using FluentValidation;

namespace Armada.CQRS.FluentValidation.Queries.Middleware;

public class FluentValidationQueryMiddleware<TQuery, TResponse>(
    IEnumerable<IValidator<TQuery>> validators)
    : IQueryMiddleware<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    public async Task<TResponse> HandleAsync(TQuery query, QueryDelegate<TResponse> next,
        CancellationToken cancellationToken = default)
    {
        var context = new ValidationContext<TQuery>(query);
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