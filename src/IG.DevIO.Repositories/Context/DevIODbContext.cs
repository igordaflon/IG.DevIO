using Microsoft.EntityFrameworkCore;
using Models;

namespace Context
{
    public class DevIODbContext : DbContext
    {
        public DevIODbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevIODbContext).Assembly);

            //Desabilita o DeleteCascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull; 

            base.OnModelCreating(modelBuilder);
        }
    }
}
