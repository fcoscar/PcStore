using System;

namespace PcStore.Domain.Core
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public bool Eliminado { get; set; }
        public int? IdUsuarioElimino { get; set; }
    }
}