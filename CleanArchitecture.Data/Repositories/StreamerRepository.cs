using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class StreamerRepository : RepositoryBase<Streamer>, IStreamerRepository
    {
        // implementar el constructor que inicialice la cadena de conexion e instancie DBContext
        public StreamerRepository(StreamerDbContext context) : base(context)
        {
            // base inicializarlo desde el padre que es RepositoryBase
        }
    }
}
