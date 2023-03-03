using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    // clase para alimentar con datos a nuestra BD
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            // voy a agregar record siempre y cuando la entidad Streamer no tenga data
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(StreamerDbContext).Name);
            }
        }
        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                // primera se va a ejecutar el metodo SaveChangesAsync de StreamerDbContext y luego los datos los que inserte los reescribirá
                new Streamer {CreatedBy = "natymarv", Nombre="Maxi HBP", Url="http://www.hbp.com"},
                new Streamer {CreatedBy = "natymarv", Nombre="Amazon VIP", Url="http://www.amazonvip.com"},
            };
        }
    }
}
