using PcStore.Domain.Core;

namespace PcStore.Domain.Entity
{
    public class Product : BaseEntity
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string? ImgUrl { get; set; }
    }
}