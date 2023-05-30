using PcStore.Domain.Core;

namespace PcStore.Domain.Entity
{
    public class Orden : BaseEntity
    {
        public int ClientId { get; set; }
        public string ClienteName { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Impuesto { get; set; }
    }
}