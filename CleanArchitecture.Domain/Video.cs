
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Video: BaseDomainModel
    {
        public string? Nombre { get; set; }
        public int StreamerId { get; set; }
        //virtual: indicamos que esta puede ser sobreescrita por una clase derivada en el futuro
        public virtual Streamer? Streamer { get; set; }
        public virtual ICollection<Actor> Actores { get; set; }
        public virtual Director Director { get; set; }
    }
}
