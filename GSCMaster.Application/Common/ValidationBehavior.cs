using FluentValidation;
using MediatR;

namespace GSCMaster.Application.Common;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
        => _validator = validator;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is not null)
        {
            var context = new ValidationContext<TRequest>(request);
            var result = await _validator.ValidateAsync(context, cancellationToken);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        return await next();
    }
}