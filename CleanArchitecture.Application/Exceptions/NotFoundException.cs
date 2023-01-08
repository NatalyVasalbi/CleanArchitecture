namespace CleanArchitecture.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        // name: nombre de la clase sobre la cual se dispara el error
        // key: obj del tipo key que represente el id del record sobre el cual se esta trabajando
        //base: porque quiero que esos valores pasen hacia el objeto padre, que es ApplicationException y me imprima un mensaje mas personalizado
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) no fue encontrado")
        {
        }
    }
}
