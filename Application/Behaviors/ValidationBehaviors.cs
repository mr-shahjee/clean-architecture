using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviors
{
    public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Post-processing logic here
            // logging, validation
            if (_validators.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);
                var result = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));
                var failures = result.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count > 0)
                {
                    throw new ValidationException(failures);

                }
            }
            //Next
            var response = await next();
            //post-processing
            return response;
        }
    }
}
