using FluentValidation;
using MediatR;
using ValidationException= CleanArchitecture.Application.Exceptions.ValidationException;

namespace CleanArchitecture.Application.Behaviours
{
    // va a tener dos parametros genericos para el request y requesponse
    // where: especificar el tipo de datos de los parametros
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        // vamos a trabajar con un conjunto de validaciones que probablemente se disparen
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        // El objetivo del ValidationBehaviour es capturar el obj request del cliente y evaluar si existe alguna validacion d alguna de las propiedades que envia el eliente
        // hay quue hacer un match entre lo que envia el cliente vs las validaciones que yo he escrito en el interior de la app
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // evaluamos is hay alguna validacion escrita en la app
            if (_validators.Any())
            {                
                var context = new ValidationContext<TRequest>(request);
                // capturar todas las validaciones que he escrito en mi app y ejecuarlas en el pipeline, en el tubo antes de que llegue a la app
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                {
                    throw new ValidationException(failures); // va a detener el request dentro del tubo
                }
            }
            return await next();
        }
    }
}
