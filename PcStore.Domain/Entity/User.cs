using PcStore.Domain.Core;

namespace PcStore.Domain.Entity
{
    public class User : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? IsAdmin { get; set; }
        public string? Password { get; set; }
    }
}