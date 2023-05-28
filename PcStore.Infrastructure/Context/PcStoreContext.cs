using Microsoft.EntityFrameworkCore;
using PcStore.Domain.Entity;

namespace PcStore.Infrastructure.Context
{
    public class PcStoreContext : DbContext
    {
        public PcStoreContext()
        {
            
        }

        public PcStoreContext(DbContextOptions<PcStoreContext> options) : base(options)
        {
            
        }
        
        public DbSet<Category> Categoria { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrdenProductos> OrdenProductos { get; set; }
    }
}