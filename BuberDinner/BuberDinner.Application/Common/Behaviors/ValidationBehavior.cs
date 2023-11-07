using BuberDinner.Application.Authentication;
using BuberDinner.Application.Common.Errors;
using FluentValidation;
using MediatR;
using OneOf;
namespace BuberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest,TResponse>
:IPipelineBehavior<TRequest,TResponse>
where TRequest:IRequest<TResponse>
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator =null)
    {
        _validator = validator;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is null) return await next();
        //before handler
        var validationResult = await _validator?.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
          return  await next();//handler execute
        }

        var firstError = validationResult.Errors.Select(e => new {code =e.ErrorCode, msg =e.ErrorMessage}).FirstOrDefault();
        var res = new GenericCommandValidateError() { Message = firstError.msg };
        return (dynamic) res;
    }
}