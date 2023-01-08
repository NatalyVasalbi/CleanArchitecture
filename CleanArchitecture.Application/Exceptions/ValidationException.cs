using FluentValidation.Results;

namespace CleanArchitecture.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        // base: para sobrecargar al padre, pase el mensaje al padre
        public ValidationException(): base("Se presentaron uno o mas errores de validacion")
        {
            Errors = new Dictionary<string, string[]>();
        }
        //this(): que sea referenciado a esta clase
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            // las excepciones van a ser leidas por esta clase y van a ser inicializadas con ese constructor
            // haciendo que los resultados de las excepciones se seteen dentro de la propiedad Errors que es el valor que devolveré al cliente
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage) // se inicializa 
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray()); // que los valores vayan a el Dictionary
        }

        // cuando se dispare esta excepcion por cuestion de validaciones, se pueden disparar un mas exepciones
        // las agrupo este conjunto de validaciones
        public IDictionary<string, string[]> Errors { get; }
    }
}
