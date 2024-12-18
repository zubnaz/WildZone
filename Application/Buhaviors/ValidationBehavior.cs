using ErrorOr;
using FluentValidation;
using MediatR;

namespace Application.Buhaviors;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(validator == null) return await next();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if(validationResult.IsValid) return await next();

        var errors = validationResult.Errors
            .ConvertAll(validationFailturs => Error.Validation
            (validationFailturs.ErrorCode,
            validationFailturs.ErrorMessage));

        return (dynamic)errors;
    }
    /*public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(validators);

        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                validators.Select(valid =>
                    valid.ValidateAsync(context,cancellationToken)
                    )).ConfigureAwait(false);

            var failures = validationResults
                .Where(valid => valid.Errors.Count >0)
                .SelectMany(valid => valid.Errors)
                .ToList();

            if(failures.Count > 0)
            {
                throw new FluentValidation.ValidationException(failures);
            }
        }
        return await next().ConfigureAwait(false);
    }*/

}
