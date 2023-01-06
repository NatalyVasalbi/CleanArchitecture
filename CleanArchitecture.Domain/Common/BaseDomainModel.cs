using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    // Esta clase es de tipo abstracta porque no permite instancias creacion de objetos directamente, solo lo utilizamos para hacer herencia
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        // propiedades de auditoria
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
