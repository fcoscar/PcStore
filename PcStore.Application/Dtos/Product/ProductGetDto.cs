using System;

namespace PcStore.Application.Dtos.Product
{

    public class ProductGetDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}