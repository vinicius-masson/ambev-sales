using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Quantity).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalPrice).HasColumnType("decimal(18,2)");

            builder.Property(p => p.Status)
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}
