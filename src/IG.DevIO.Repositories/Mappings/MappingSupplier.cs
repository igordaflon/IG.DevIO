using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Mappings
{
    public class MappingSupplier : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.Document).IsRequired().HasColumnType("varchar(14)");


            //1 : 1 => Supplier - Address
            builder.HasOne(s => s.Address).WithOne(a => a.Supplier);

            //1 : N => Supplier - Products
            builder.HasMany(p => p.Products).WithOne(s => s.Supplier).HasForeignKey(s => s.SupplierId);

            builder.ToTable("Suppliers");
        }
    }
}
