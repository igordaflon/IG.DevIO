using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Mappings
{
    public class MappingAddress : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Street).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.Number).IsRequired().HasColumnType("varchar(20)");
            builder.Property(p => p.ZipCode).IsRequired().HasColumnType("varchar(8)");
            builder.Property(p => p.Complement).IsRequired().HasColumnType("varchar(30)");
            builder.Property(p => p.Neighborhood).IsRequired().HasColumnType("varchar(30)");
            builder.Property(p => p.City).IsRequired().HasColumnType("varchar(30)");
            builder.Property(p => p.State).IsRequired().HasColumnType("varchar(30)");

            builder.ToTable("Addresses");
        }
    }
}
