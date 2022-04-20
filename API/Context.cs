using Microsoft.EntityFrameworkCore;
using API.Entities;
namespace API
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<DeliveryOrderDetail> DeliveryOrderDetail { get; set; }
        public DbSet<ProductInstance> ProductInstance { get; set; }
        public DbSet<ProductLine> ProductLine { get; set; }
        public DbSet<TagReader>tagReaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryOrderDetail>()
                .HasKey(c => new { c.product_instance_id, c.delivery_order_id });

            modelBuilder.Entity<ProductInstance>()
                .HasKey(c => new { c.product_intance_id, c.product_line_id });
        }
    }
}
