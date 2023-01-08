using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // analizar los metodos Handles de los Commands y Querys
            try
            {
                // si no hay errores todo pase normal
                return await next();
            }
            catch (Exception ex)
            {
                // si hay errores 
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Application Request: Sucedio una excepcion para el request {Name} {@Request}", requestName, request);
                //lanzo la excepcion
                throw;
            }
        }
    }
}
