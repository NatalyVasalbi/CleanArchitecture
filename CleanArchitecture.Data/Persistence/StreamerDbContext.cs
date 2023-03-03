using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContext : DbContext
    {
        // DbContextOptions incluye la cadena de conexion
        // Setea la cadena de conexion
        // base: otro componente va a ser el encargado de setear la cadena de conexion
        public StreamerDbContext(DbContextOptions<StreamerDbContext> options): base (options)
        {
        }
        // CADENA DE CONEXION HARDCODEADA
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress;
        //        Initial Catalog=Streamer;Integrated Security=True");
        //}
        //convierto las clases(singular) en entidades(plural)


        // creamos un nuevo metodo para setear los valores de auditoria de BaseDomainModel
        // se va a ejecutar antes de insertar o actualizar el valor, el nuevo record dentro de la BD
        public override Task<int>SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // le indicamos que recorra todas las entidades antes de hacer la insercion
            foreach(var entry in ChangeTracker.Entries<BaseDomainModel>())// con la entidad base con la que estamos trabajando "BaseDomainModel"
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate=DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate=DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }            
            return base.SaveChangesAsync(cancellationToken);
        }
        //protected override void onModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Streamer>()
        //        .HasMany(m=>m.Videos)
        //        .WithMany(m=>m.Streamer)
        //        .HasForeignKey(m=>m.StreamerId)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Restrict);
        //}
        
        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
    }
}
